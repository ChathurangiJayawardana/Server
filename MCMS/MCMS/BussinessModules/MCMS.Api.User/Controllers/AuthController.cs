using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MCMS.Common.MCMS.Common.DataModel.Models;
using MCMS.Common.MCMS.Common.Utils.Cryptography;
using MCMS.Common.MCMS.Common.Utils.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MCMS.BussinessModules.MCMS.Api.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly medicalcenterContext _context;

        private readonly AppSettings _appSettings;

        public AuthController(medicalcenterContext context,  IOptions<AppSettings> appsettings)
        {
            _context = context;
            _appSettings = appsettings.Value;
        }

        [HttpPost("login")]
        public ActionResult Login(Users userParam)
        {
            string pass = Hashing.CalculateMD5Hash(userParam.Password);
            var user = _context.Users
                .Include(u => u.UserRoleGroups)
                .ThenInclude(rg => rg.RoleGroup)
                .ThenInclude(rco => rco.RoleCarryOuts)
                .ThenInclude(r => r.Role)
                .SingleOrDefault(u => u.Email == userParam.Email 
            && u.Password == pass );
            

            if(user == null)
            {
                return null;
            }

            //List<string> roles = new List<string>();

            //foreach(UserRoleGroups urg in user.UserRoleGroups)
            //{
            //    RoleGroups rg = urg.RoleGroup;

            //    foreach(RoleCarryOuts rco in rg.RoleCarryOuts)
            //    {
            //        roles.Add(rco.Role.Description);
            //    }
            //}

            //string role = user.UserRoleGroups.SingleOrDefault().RoleGroup.RoleCarryOuts.SingleOrDefault().Role.Description;

            //security key
            string securityKey = _appSettings.JwtKey;
            //symmetric security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing credentials
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //add claims
            var claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            //claims.Add(new Claim(ClaimTypes.Role, "Reader"));
            //claims.Add(new Claim("RoleGroup", role));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            foreach (UserRoleGroups urg in user.UserRoleGroups)
            {
                RoleGroups rg = urg.RoleGroup;

                claims.Add(new Claim("RoleGroup", rg.Name));

                foreach (RoleCarryOuts rco in rg.RoleCarryOuts)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rco.Role.Description));
                }
            }

            claims.Add(new Claim("Id", user.Id.ToString()));


            //create token
            var token = new JwtSecurityToken(
                    issuer: "mutants",
                    audience: "users",
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                    , claims: claims
                );

            user.Password = null;
            user.Token = new JwtSecurityTokenHandler().WriteToken(token);

            //return token
            return Ok(user);
        }
    }
}
