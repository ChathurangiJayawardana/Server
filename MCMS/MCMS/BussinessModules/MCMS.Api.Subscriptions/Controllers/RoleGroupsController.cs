using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCMS.Common.MCMS.Common.DataModel.Models;

namespace MCMS.BussinessModules.MCMS.Api.Subscriptions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleGroupsController : ControllerBase
    {
        private readonly medicalcenterContext _context;

        public RoleGroupsController(medicalcenterContext context)
        {
            _context = context;
        }

        // GET: api/RoleGroups
        [HttpGet]
        public IEnumerable<RoleGroups> GetRoleGroups()
        {
            return _context.RoleGroups;
        }

        // GET: api/RoleGroups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleGroups([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleGroups = await _context.RoleGroups.FindAsync(id);

            if (roleGroups == null)
            {
                return NotFound();
            }

            return Ok(roleGroups);
        }

        // PUT: api/RoleGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleGroups([FromRoute] int id, [FromBody] RoleGroups roleGroups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roleGroups.Id)
            {
                return BadRequest();
            }

            _context.Entry(roleGroups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleGroupsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RoleGroups
        [HttpPost]
        public async Task<IActionResult> PostRoleGroups([FromBody] RoleGroups roleGroups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RoleGroups.Add(roleGroups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoleGroups", new { id = roleGroups.Id }, roleGroups);
        }

        // DELETE: api/RoleGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleGroups([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleGroups = await _context.RoleGroups.FindAsync(id);
            if (roleGroups == null)
            {
                return NotFound();
            }

            _context.RoleGroups.Remove(roleGroups);
            await _context.SaveChangesAsync();

            return Ok(roleGroups);
        }

        private bool RoleGroupsExists(int id)
        {
            return _context.RoleGroups.Any(e => e.Id == id);
        }
    }
}