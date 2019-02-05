using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCMS.Common.MCMS.Common.DataModel.Models;
using Microsoft.AspNetCore.Authorization;

namespace MCMS.BussinessModules.MCMS.Api.Subscriptions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class ClinicsController : ControllerBase
    {
        private readonly medicalcenterContext _context;

        public ClinicsController(medicalcenterContext context)
        {
            _context = context;
        }

        // GET: api/Clinics
        [HttpGet]
        public IEnumerable<Clinics> GetClinics()
        {
            return _context.Clinics;
        }

        // GET: api/Clinics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClinics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clinics = await _context.Clinics.FindAsync(id);

            if (clinics == null)
            {
                return NotFound();
            }

            return Ok(clinics);
        }

        // PUT: api/Clinics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinics([FromRoute] int id, [FromBody] Clinics clinics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clinics.Id)
            {
                return BadRequest();
            }

            _context.Entry(clinics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicsExists(id))
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

        // POST: api/Clinics
        [HttpPost]
        public async Task<IActionResult> PostClinics([FromBody] Clinics clinics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Clinics.Add(clinics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClinics", new { id = clinics.Id }, clinics);
        }

        // DELETE: api/Clinics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clinics = await _context.Clinics.FindAsync(id);
            if (clinics == null)
            {
                return NotFound();
            }

            _context.Clinics.Remove(clinics);
            await _context.SaveChangesAsync();

            return Ok(clinics);
        }

        private bool ClinicsExists(int id)
        {
            return _context.Clinics.Any(e => e.Id == id);
        }
    }
}