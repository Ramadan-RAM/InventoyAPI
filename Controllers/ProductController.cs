using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AngularERPApi.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            //return await _context.Products.ToListAsync();

            var products = (from p in _context.Products
                            join c in _context.Categories on p.CategoryId equals c.CategoryId

                             select new Product
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 ProductCode = p.ProductCode,
                                 CategoryId = p.CategoryId,
                                 CategoryName = c.CategoryName,
                                 Quantity = p.Quantity,
                                 Cost = p.Cost,
                                 Price = p.Price,
                                 Description = p.Description,
                                 ImageProduct = p.ImageProduct,
                                 IsAvailable = p.IsAvailable,
                                 DelFlage = p.DelFlage
                                 
                             }
                        ).ToListAsync();

            return await products;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("SaveProductImage")]
        [HttpPost]
        public JsonResult SaveFileImage()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = webHostEnvironment.ContentRootPath + "/prouductImg/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("");
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
