using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;
using AngularERPApi.Services;
using System;

namespace AngularERPApi.Controllers
{
    [Route("api/SalesDetail")]
    [ApiController]
    public class SalesDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SalesDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/SalesDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesDetail>>> GetSalesDetail()
        {
            var saldet = (from sd in _context.SalesDetails
                          join sls in _context.Sales on sd.SalesId equals sls.SalesId
                          join st in _context.StoreData on sd.StoreId equals st.StoreId
                          join ct in _context.Categories on sd.CategoryId equals ct.CategoryId
                          join pro in _context.Products on sd.ProductId equals pro.ProductId
                          join cr in _context.Currency on sd.CurrencyId equals cr.CurrencyId

                          select new SalesDetail
                          {
                               SalesDetailId = sd.SalesDetailId,
                               SalesId = sd.SalesDetailId,
                               SalesName = sls.SalesName,
                               StoreId = sd.StoreId,
                               StoreName = st.StoreName,
                               CategoryId = sd.CategoryId,
                               CategoryName = ct.CategoryName,
                               ProductId = sd.ProductId,
                               ProductName = pro.ProductName,
                               CurrencyId = sd.CurrencyId,
                               CurrencyName = cr.CurrencyName,
                               SalesPrice = sd.SalesPrice,
                               ItemQuantity = sd.ItemQuantity,
                               ItemValue = sd.ItemValue,
                               Amount = sd.Amount,
                               DiscountPercentage = sd.DiscountPercentage,
                               DiscountAmount = sd.DiscountAmount,
                               SubTotal = sd.SubTotal,
                               TaxPercentage = sd.TaxPercentage,
                               TaxAmount = sd.TaxAmount,
                               Total = sd.Total,
                               Description = sd.Description,
                               DelFlage = sd.DelFlage
                          }

                          ).ToListAsync();

            return await saldet;
        }

        // GET: api/SalesDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesDetail>> GetSalesDetailById(int id, SalesDetail salesdetail)
        {

            if (id != salesdetail.SalesId)
            {
                return BadRequest();
            }
            
            var saleDetail = (from sd in _context.SalesDetails
             join sls in _context.Sales on sd.SalesId equals sls.SalesId
             join st in _context.StoreData on sd.StoreId equals st.StoreId
             join ct in _context.Categories on sd.CategoryId equals ct.CategoryId
             join pro in _context.Products on sd.ProductId equals pro.ProductId
             join cr in _context.Currency on sd.CurrencyId equals cr.CurrencyId
                              select new SalesDetail
                              {
                                  SalesDetailId = sd.SalesDetailId,
                                  SalesId = sd.SalesDetailId,
                                  SalesName = sls.SalesName,
                                  StoreId = sd.StoreId,
                                  StoreName = st.StoreName,
                                  CategoryId = sd.CategoryId,
                                  CategoryName = ct.CategoryName,
                                  ProductId = sd.ProductId,
                                  ProductName = pro.ProductName,
                                  CurrencyId = sd.CurrencyId,
                                  CurrencyName = cr.CurrencyName,
                                  SalesPrice = sd.SalesPrice,
                                  ItemQuantity = sd.ItemQuantity,
                                  ItemValue = sd.ItemValue,
                                  Amount = sd.Amount,
                                  DiscountPercentage = sd.DiscountPercentage,
                                  DiscountAmount = sd.DiscountAmount,
                                  SubTotal = sd.SubTotal,
                                  TaxPercentage = sd.TaxPercentage,
                                  TaxAmount = sd.TaxAmount,
                                  Total = sd.Total,
                                  Description = sd.Description,
                                  DelFlage = sd.DelFlage
                              }

                          ).ToListAsync();

            try
            {
               await _context.SalesDetails.FindAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesDetailExists(id))
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

        private SalesDetail Recalculate(SalesDetail salesdetail)
        {
            try
            {
                salesdetail.Amount = (double)(salesdetail.ItemQuantity * salesdetail.SalesPrice);
                salesdetail.DiscountAmount = (salesdetail.DiscountPercentage * salesdetail.Amount) / 100.0;
                salesdetail.SubTotal = salesdetail.Amount - salesdetail.DiscountAmount;
                salesdetail.TaxAmount = (salesdetail.TaxPercentage * salesdetail.SubTotal) / 100.0;
                salesdetail.Total = salesdetail.SubTotal + salesdetail.TaxAmount;

            }
            catch (Exception)
            {

                throw;
            }

            return salesdetail;
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
                    List<SalesDetail> saldet = new List<SalesDetail>();
                    saldet = _context.SalesDetails.Where(x => x.SalesId.Equals(SalesId)).ToList();

                    //update master data by its lines
                    sales.Amount = saldet.Sum(x => x.Amount);
                    sales.SubTotal = saldet.Sum(x => x.SubTotal);

                    sales.Discount = saldet.Sum(x => x.DiscountAmount);
                    sales.Tax = saldet.Sum(x => x.TaxAmount);

                    sales.Total = sales.Freight + saldet.Sum(x => x.Total);

                    sales.RemainValue = (decimal)(sales.Freight + saldet.Sum(x => x.Total));

                    sales.PayedValue = (decimal)saldet.Sum(x => x.Total);

                    sales.RemainValue = (decimal)saldet.Sum(x => x.Total) - sales.PayedValue;

                    _context.Update(sales);

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/SalesDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesDetail(int id, SalesDetail salesdetail)
        {
            if (id != salesdetail.SalesDetailId)
            {
                return BadRequest();
            }
               Recalculate(salesdetail);
             _context.Entry(salesdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                UpdateSales(salesdetail.SalesId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesDetailExists(id))
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

        // POST: api/SalesDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesDetail>> PostSalesDetail(SalesDetail salesdetail)
        {
            Recalculate(salesdetail);
            _context.SalesDetails.Add(salesdetail);
            await _context.SaveChangesAsync();
            UpdateSales(salesdetail.SalesId);
            return Ok(salesdetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesDetail(int id)
        {
            var salesdetail = await _context.SalesDetails.FindAsync(id);
            if (salesdetail == null)
            {
                return NotFound();
            }

            _context.SalesDetails.Remove(salesdetail);
            await _context.SaveChangesAsync();
            UpdateSales(salesdetail.SalesId);
            return Ok(salesdetail);
        }

        private bool SalesDetailExists(int id)
        {
            return _context.SalesDetails.Any(e => e.SalesDetailId == id);
        }

    }
}
