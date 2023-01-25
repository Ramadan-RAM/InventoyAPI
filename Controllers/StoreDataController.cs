using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;

namespace AngularERPApi.Controllers
{
    [Route("api/StoreData")]
    [ApiController]
    public class StoreDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoreDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StoreData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreData>>> GetStoreData()
        {
            return await _context.StoreData.ToListAsync();
        }

        // GET: api/StoreData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreData>> GetStoreData(int id)
        {
            var storeData = await _context.StoreData.FindAsync(id);

            if (storeData == null)
            {
                return NotFound();
            }

            return storeData;
        }

        // PUT: api/StoreData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreData(int id, StoreData storeData)
        {
            if (id != storeData.StoreId)
            {
                return BadRequest();
            }

            _context.Entry(storeData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreDataExists(id))
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

        // POST: api/StoreData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoreData>> PostStoreData(StoreData storeData)
        {
            _context.StoreData.Add(storeData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoreData", new { id = storeData.StoreId }, storeData);
        }

        // DELETE: api/StoreData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreData(int id)
        {
            var storeData = await _context.StoreData.FindAsync(id);
            if (storeData == null)
            {
                return NotFound();
            }

            _context.StoreData.Remove(storeData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreDataExists(int id)
        {
            return _context.StoreData.Any(e => e.StoreId == id);
        }
    }
}
