using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCMS.Common.MCMS.Common.DataModel.Models;
using Microsoft.AspNetCore.Authorization;

namespace MCMS.BussinessModules.MCMS.Api.Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PrescriptionsController : ControllerBase
    {
        private readonly medicalcenterContext _context;

        public PrescriptionsController(medicalcenterContext context)
        {
            _context = context;
        }

        // GET: api/Prescriptions
        [HttpGet]
        public IEnumerable<Prescriptions> GetPrescriptions()
        {
            var prescriptions =  _context.Prescriptions;
            
            return prescriptions;
        }

        // GET: api/Prescriptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prescriptions = await _context.Prescriptions.FindAsync(id);

            if (prescriptions == null)
            {
                return NotFound();
            }

            return Ok(prescriptions);
        }

        // PUT: api/Prescriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescriptions([FromRoute] int id, [FromBody] Prescriptions prescriptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prescriptions.Id)
            {
                return BadRequest();
            }

            _context.Entry(prescriptions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescriptionsExists(id))
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

        // POST: api/Prescriptions
        [HttpPost]
        public async Task<IActionResult> PostPrescriptions([FromBody] Prescriptions prescriptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Prescriptions.Add(prescriptions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescriptions", new { id = prescriptions.Id }, prescriptions);
        }

        // DELETE: api/Prescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescriptions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prescriptions = await _context.Prescriptions.FindAsync(id);
            if (prescriptions == null)
            {
                return NotFound();
            }

            _context.Prescriptions.Remove(prescriptions);
            await _context.SaveChangesAsync();

            return Ok(prescriptions);
        }

        private bool PrescriptionsExists(int id)
        {
            return _context.Prescriptions.Any(e => e.Id == id);
        }
    }
}