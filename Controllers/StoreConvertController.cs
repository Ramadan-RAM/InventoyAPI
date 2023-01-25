using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;

namespace AngularERPApi.Controllers
{
    [Route("api/StoreConvert")]
    [ApiController]
    public class StoreConvertController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoreConvertController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StoreConvert
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreConvert>>> GetStoreConverts()
        {
            // return await _context.StoreConverts.ToListAsync();

            var storeConvert = (from sc in _context.StoreConverts
                                   join sf in _context.StoreData on sc.StoreFromId equals sf.StoreId
                                   join st in _context.StoreData on sc.StoreToId equals st.StoreId
                                   join p in _context.Products on sc.ProductId equals p.ProductId

                                select new StoreConvert
                                {
                                    StoreConvertId = sc.StoreConvertId,
                                    ProductId = sc.ProductId,
                                    ProductName = p.ProductName,
                                    StoreFromId = sc.StoreFromId,
                                    StoreNameFrom = sf.StoreName,
                                    StoreToId = sc.StoreToId,
                                    StoreNameTo = st.StoreName,
                                    ItemQuantity = sc.ItemQuantity,
                                    ConDate = sc.ConDate,
                                    Notes = sc.Notes,
                                    DelFlage = sc.DelFlage
                                }
                     ).ToListAsync();

            return await storeConvert;
        }

        // GET: api/StoreConvert/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreConvert>> GetStoreConvert(int id)
        {
            var storeConvert = await _context.StoreConverts.FindAsync(id);

            if (storeConvert == null)
            {
                return NotFound();
            }

            return storeConvert;
        }

        // PUT: api/StoreConvert/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreConvert(int id, StoreConvert storeConvert)
        {
            if (id != storeConvert.StoreConvertId)
            {
                return BadRequest();
            }

            _context.Entry(storeConvert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreConvertExists(id))
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

        // POST: api/StoreConvert
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /* [HttpPost]
        public async Task<ActionResult<StoreConvert>> PostStoreConvert(StoreConvert storeConvert)
        {
            _context.StoreConverts.Add(storeConvert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoreConvert", new { id = storeConvert.StoreConvertId }, storeConvert);
        }*/

        [Route("StoreConvertInsert")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<StoreConvert>>> StoreConvertInsert(StoreConvert stConv)
        {

            string StoredProc = $"exec Sp_StoreConvertInsert @StoreFromId = {stConv.StoreFromId},@StoreToId = '{stConv.StoreToId}',@ProductId = '{stConv.ProductId}',@ItemQuantity = '{stConv.ItemQuantity}',@ConDate = '{stConv.ConDate}',@Notes = '{stConv.Notes}'";

            return await _context.StoreConverts.FromSqlRaw(StoredProc).ToListAsync();


            //var StoredProc = $"Sp_StoreConvertInsert {stConv.StoreFromId},{stConv.StoreToId},{stConv.ProductId},{stConv.ItemQuantity},{stConv.ConDate},{stConv.Notes}";

            // await _context.Database.ExecuteSqlRawAsync(StoredProc);

            //var StoreConverts = _context.StoreConverts.ToListAsync();

            /*return await _context.Database.ExecuteSqlRawAsync($"Sp_StoreConvertInsert {stConv.StoreFromId},{stConv.StoreToId},{stConv.ProductId},{stConv.ItemQuantity},{stConv.ConDate},{stConv.Notes}").ToListAsync();*/
        }

        // DELETE: api/StoreConvert/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreConvert(int id)
        {
            var storeConvert = await _context.StoreConverts.FindAsync(id);
            if (storeConvert == null)
            {
                return NotFound();
            }

            _context.StoreConverts.Remove(storeConvert);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreConvertExists(int id)
        {
            return _context.StoreConverts.Any(e => e.StoreConvertId == id);
        }
    }
}
