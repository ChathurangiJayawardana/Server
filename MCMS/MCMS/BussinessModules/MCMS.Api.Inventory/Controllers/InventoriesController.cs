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
    [Authorize(Roles = "admin, manager, pharmacist")]
    public class InventoriesController : ControllerBase
    {
        private readonly medicalcenterContext _context;

        public InventoriesController(medicalcenterContext context)
        {
            _context = context;
        }

        // GET: api/Inventories
        [HttpGet]
        public IEnumerable<Inventories> GetInventories()
        {
            return _context.Inventories;
        }

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventories = await _context.Inventories.FindAsync(id);

            if (inventories == null)
            {
                return NotFound();
            }

            return Ok(inventories);
        }

        // PUT: api/Inventories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventories([FromRoute] int id, [FromBody] Inventories inventories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventories.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoriesExists(id))
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

        // POST: api/Inventories
        [HttpPost]
        public async Task<IActionResult> PostInventories([FromBody] Inventories inventories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Inventories.Add(inventories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventories", new { id = inventories.Id }, inventories);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventories = await _context.Inventories.FindAsync(id);
            if (inventories == null)
            {
                return NotFound();
            }

            _context.Inventories.Remove(inventories);
            await _context.SaveChangesAsync();

            return Ok(inventories);
        }

        private bool InventoriesExists(int id)
        {
            return _context.Inventories.Any(e => e.Id == id);
        }
    }
}