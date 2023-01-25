using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;

namespace AngularERPApi.Controllers
{
    [Route("api/VendorType")]
    [ApiController]
    public class VendorTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendorTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/VendorTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorType>>> GetVendorType()
        {
            return await _context.VendorType.ToListAsync();
        }

        // GET: api/VendorTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorType>> GetVendorType(int id)
        {
            var VendorType = await _context.VendorType.FindAsync(id);

            if (VendorType == null)
            {
                return NotFound();
            }

            return VendorType;
        }

        // PUT: api/VendorTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorType(int id, VendorType vendorType)
        {
            if (id != vendorType.VendorTypeId)
            {
                return BadRequest();
            }

            _context.Entry(vendorType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorTypeExists(id))
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

        // POST: api/VendorTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VendorType>> PostVendorType(VendorType vendorType)
        {
            _context.VendorType.Add(vendorType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendorType", new { id = vendorType.VendorTypeId }, vendorType);
        }

        // DELETE: api/VendorTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendorType(int id)
        {
            var vendorType = await _context.VendorType.FindAsync(id);
            if (vendorType == null)
            {
                return NotFound();
            }

            _context.VendorType.Remove(vendorType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorTypeExists(int id)
        {
            return _context.VendorType.Any(e => e.VendorTypeId == id);
        }
    }
}
