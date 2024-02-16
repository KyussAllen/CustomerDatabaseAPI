using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerDatabaseAPI.Data;
using CustomerDatabaseAPI.Models;

namespace CustomerDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfosController : ControllerBase
    {
        private readonly CustomerDatabaseAPIContext _context;

        public CustomerInfosController(CustomerDatabaseAPIContext context)
        {
            _context = context;
        }

        // GET: api/CustomerInfos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInformation>>> GetCustomerInformation()
        {
            return await _context.CustomerInformation.ToListAsync();
        }

        // GET: api/CustomerInfos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInformation>> GetCustomerInformation(int id)
        {
            var customerInformation = await _context.CustomerInformation.FindAsync(id);

            if (customerInformation == null)
            {
                return NotFound();
            }

            return customerInformation;
        }

        // PUT: api/CustomerInfos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerInformation(int id, CustomerInformation customerInformation)
        {
            if (id != customerInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInformationExists(id))
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

        // POST: api/CustomerInfos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerInformation>> PostCustomerInformation(CustomerInformation customerInformation)
        {
            _context.CustomerInformation.Add(customerInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerInformation", new { id = customerInformation.Id }, customerInformation);
        }

        // DELETE: api/CustomerInfos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerInformation(int id)
        {
            var customerInformation = await _context.CustomerInformation.FindAsync(id);
            if (customerInformation == null)
            {
                return NotFound();
            }

            _context.CustomerInformation.Remove(customerInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerInformationExists(int id)
        {
            return _context.CustomerInformation.Any(e => e.Id == id);
        }
    }
}
