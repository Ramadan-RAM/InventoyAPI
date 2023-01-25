using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;

namespace AngularERPApi.Controllers
{
    [Route("api/StoreQuantity")]
    [ApiController]
    public class StoreQuantitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoreQuantitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StoreQuantities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreQuantity>>> GetStoreQuantities()
        {
            // return await _context.StoreQuantities.ToListAsync();

            var storeQuantities = (from sq in _context.StoreQuantities
                                   join s in _context.StoreData on sq.StoreId equals s.StoreId
                                   join p in _context.Products on sq.ProductId equals p.ProductId

                                   select new StoreQuantity
                                   {
                                        QuanId = sq.QuanId,
                                        StoreId = sq.StoreId,
                                        StoreName = s.StoreName,
                                        ProductId = sq.ProductId,
                                        ProductName = p.ProductName,
                                       ItemQuantity = sq.ItemQuantity,
                                       DelFlage = sq.DelFlage
                                   }
                       ).ToListAsync();

            return await storeQuantities;
        }

        // GET: api/StoreQuantities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreQuantity>> GetStoreQuantity(int id)
        {
            var storeQuantity = await _context.StoreQuantities.FindAsync(id);

            if (storeQuantity == null)
            {
                return NotFound();
            }

            return storeQuantity;
        }

        // PUT: api/StoreQuantities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreQuantity(int id, StoreQuantity storeQuantity)
        {
            if (id != storeQuantity.QuanId)
            {
                return BadRequest();
            }

            _context.Entry(storeQuantity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreQuantityExists(id))
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

        // POST: api/StoreQuantities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoreQuantity>> PostStoreQuantity(StoreQuantity storeQuantity)
        {
            _context.StoreQuantities.Add(storeQuantity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoreQuantity", new { id = storeQuantity.QuanId }, storeQuantity);
        }

        [HttpPost]
        [Route("DistributeProductAuto")]
        public async Task<ActionResult<IEnumerable<StoreQuantity>>> DistributeProductAuto()
        {
            var StoredProc = $"Sp_DistributeProductAuto";
            return await _context.StoreQuantities.FromSqlRaw<StoreQuantity>(StoredProc).ToListAsync();
        }


        
        [HttpPost]
        [Route("StoreQuantityInsert")]
        public async Task<ActionResult<IEnumerable<StoreQuantity>>> StoreQuantityInsert(StoreQuantity storeQuantity)
        {
            //return await _context.StoreQuantities.FromSqlRaw("Sp_StoreQuantityInsert {0}", storeQuantity).ToListAsync();
            
                
            string StoredProc = "exec Sp_StoreQuantityInsert" +
                    "@StoreId = " + storeQuantity.StoreId + "," +
                    "@ProductId = '" + storeQuantity.ProductId +
                     "'";

            return await _context.StoreQuantities.FromSqlRaw(StoredProc).ToListAsync();
        }


        //[HttpPost]
        //[Route("DistributeProductAuto")]
        //public StoreQuantity DistributeProductAuto()
        //{
        //    return _context.StoreQuantities.FromSqlRaw<StoreQuantity>("exec Sp_DistributeProductAuto")
        //        .ToList().FirstOrDefault();
        //}

        // DELETE: api/StoreQuantities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreQuantity(int id)
        {
            var storeQuantity = await _context.StoreQuantities.FindAsync(id);
            if (storeQuantity == null)
            {
                return NotFound();
            }

            _context.StoreQuantities.Remove(storeQuantity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreQuantityExists(int id)
        {
            return _context.StoreQuantities.Any(e => e.QuanId == id);
        }
    }
}
