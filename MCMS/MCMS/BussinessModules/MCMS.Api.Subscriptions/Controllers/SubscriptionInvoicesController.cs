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
    public class SubscriptionInvoicesController : ControllerBase
    {
        private readonly medicalcenterContext _context;

        public SubscriptionInvoicesController(medicalcenterContext context)
        {
            _context = context;
        }

        // GET: api/SubscriptionInvoices
        [HttpGet]
        public IEnumerable<SubscriptionInvoices> GetSubscriptionInvoices()
        {
            return _context.SubscriptionInvoices;
        }

        // GET: api/SubscriptionInvoices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionInvoices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriptionInvoices = await _context.SubscriptionInvoices.FindAsync(id);

            if (subscriptionInvoices == null)
            {
                return NotFound();
            }

            return Ok(subscriptionInvoices);
        }

        // PUT: api/SubscriptionInvoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionInvoices([FromRoute] int id, [FromBody] SubscriptionInvoices subscriptionInvoices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriptionInvoices.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscriptionInvoices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionInvoicesExists(id))
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

        // POST: api/SubscriptionInvoices
        [HttpPost]
        public async Task<IActionResult> PostSubscriptionInvoices([FromBody] SubscriptionInvoices subscriptionInvoices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SubscriptionInvoices.Add(subscriptionInvoices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptionInvoices", new { id = subscriptionInvoices.Id }, subscriptionInvoices);
        }

        // DELETE: api/SubscriptionInvoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionInvoices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriptionInvoices = await _context.SubscriptionInvoices.FindAsync(id);
            if (subscriptionInvoices == null)
            {
                return NotFound();
            }

            _context.SubscriptionInvoices.Remove(subscriptionInvoices);
            await _context.SaveChangesAsync();

            return Ok(subscriptionInvoices);
        }

        private bool SubscriptionInvoicesExists(int id)
        {
            return _context.SubscriptionInvoices.Any(e => e.Id == id);
        }
    }
}