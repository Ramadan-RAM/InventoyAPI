using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;

namespace AngularERPApi.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            //return await _context.Customers.ToListAsync();

            var customers = (from c in _context.Customers
                             join ct in _context.CustomerType  on c.CustomerTypeId equals ct.CustomerTypeId
                             join cn in _context.Country on c.CountryId equals cn.CountryId

                             select new Customer
                             {
                                 CustomerId = c.CustomerId,
                                 CustomerName = c.CustomerName,
                                 CustomerTypeId = c.CustomerTypeId,
                                 CustomerTypeName = ct.CustomerTypeName,
                                 CountryId = c.CountryId,
                                 CountryName = cn.CountryName,
                                 Phone = c.Phone,
                                 Mobaile = c.Mobaile,
                                 Address = c.Address,
                                 State = c.State,
                                 ZipCode = c.ZipCode,
                                 Email = c.Email,
                                 ContactPerson = c.ContactPerson,
                                 Notes = c.Notes,
                                 Debit = c.Debit,
                                 DelFlage = c.DelFlage
                             }
                          ).ToListAsync();

            return await customers;
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

       

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
