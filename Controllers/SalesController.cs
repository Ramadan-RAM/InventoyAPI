using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;
using AngularERPApi.Services;
using System;
using AngularERPApi.Models.SyncfusionViewModels;

namespace AngularERPApi.Controllers
{

    [Route("api/Sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;
        public SalesController(ApplicationDbContext context, INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/Sales

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSale()
        {
            var sal = (from s in _context.Sales
                              join c in _context.Customers on s.CustomerId equals c.CustomerId

                             select new Sales
                             {
                                 SalesId = s.SalesId,
                                 SalesName = s.SalesName,
                                 CustomerId = s.CustomerId,
                                 CustomerName = c.CustomerName,
                                 SalesDate = s.SalesDate,
                                 DeliveryDate = s.DeliveryDate,
                                 PayedValue  = s.PayedValue,
                                 RemainValue = s.RemainValue,
                                 Amount = s.Amount,
                                 SubTotal = s.SubTotal,
                                 Discount = s.Discount,
                                 Tax = s.Tax,
                                 Freight = s.Freight,
                                 Total = s.Total,
                                 DelFlage = s.DelFlage
                             }
                          ).ToListAsync();
           
            return await sal;
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> GetSalesById(int id)
        {
            var sales = await _context.Sales.FindAsync(id);

            if (sales == null)
            {
                return NotFound();
            }

            return sales;
        }

        private void UpdateSales(int SalesId)
        {
            try
            {
                Sales sales = new Sales();
                sales = _context.Sales
                    .Where(x => x.SalesId.Equals(SalesId))
                    .FirstOrDefault();

                if (sales != null)
                {
                    List<SalesDetail> lines = new List<SalesDetail>();
                    lines = _context.SalesDetails.Where(x => x.SalesId.Equals(SalesId)).ToList();

                    //update master data by its lines
                    sales.Amount = lines.Sum(x => x.Amount);
                    sales.SubTotal = lines.Sum(x => x.SubTotal);

                    sales.Discount = lines.Sum(x => x.DiscountAmount);
                    sales.Tax = lines.Sum(x => x.TaxAmount);

                    sales.Total = sales.Freight + lines.Sum(x => x.Total);

                    sales.RemainValue = (decimal)(sales.Freight + lines.Sum(x => x.Total));

                    sales.PayedValue = (decimal)lines.Sum(x => x.Total);

                    sales.RemainValue = (decimal)lines.Sum(x => x.Total) - sales.PayedValue;

                    _context.Update(sales);

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSales(int id, Sales sales)
        {
            if (id != sales.SalesId)
            {
                return BadRequest();
            }

            _context.Entry(sales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                UpdateSales(sales.SalesId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
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

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sales>> PostSales(Sales sales)
        {
            sales.SalesName = _numberSequence.GetNumberSequence("SO");
            _context.Sales.Add(sales);
            await _context.SaveChangesAsync();
            UpdateSales(sales.SalesId);
            return CreatedAtAction("GetSale", new { id = sales.SalesId},sales);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSales(int id)
        {
            var sales = await _context.Sales.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sales);
            await _context.SaveChangesAsync();

            return Ok(sales);
        }

        private bool SalesExists(int id)
        {
            return _context.Sales.Any(e => e.SalesId == id);
        }

        
    }
}
