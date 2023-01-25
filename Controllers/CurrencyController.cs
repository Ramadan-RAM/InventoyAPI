using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;


namespace AngularERPApi.Controllers
{
    [Route("api/Currency")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurrencyController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrency()
        {
            return await _context.Currency.ToListAsync();
        }

        // GET: api/Currency/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(int id)
        {
            var Currency = await _context.Currency.FindAsync(id);

            if (Currency == null)
            {
                return NotFound();
            }

            return Currency;
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(int id, Currency Currency)
        {
            if (id != Currency.CurrencyId)
            {
                return BadRequest();
            }

            _context.Entry(Currency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
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
        public async Task<ActionResult<Currency>> PostCurrency(Currency Currency)
        {
            _context.Currency.Add(Currency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrency", new { id = Currency.CurrencyId }, Currency);
        }

        // DELETE: api/Currency/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            var Currency = await _context.Currency.FindAsync(id);
            if (Currency == null)
            {
                return NotFound();
            }

            _context.Currency.Remove(Currency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurrencyExists(int id)
        {
            return _context.Currency.Any(e => e.CurrencyId == id);
        }

    }
}
