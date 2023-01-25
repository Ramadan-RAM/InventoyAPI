using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;

namespace AngularERPApi.Controllers
{
    [Route("api/Vendor")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
        {
            //return await _context.Vendors.ToListAsync();

            var vendors = (from v in _context.Vendors
                           join ven in _context.VendorType on v.VendorTypeId equals ven.VendorTypeId
                           join cn in _context.Country on v.CountryId equals cn.CountryId

                           select new Vendor
                           {
                               VendorId = v.VendorId,
                               VendorName = v.VendorName,
                               VendorTypeId = v.VendorTypeId,
                               VendorTypeName = ven.VendorTypeName,
                               CountryId = v.CountryId,
                               CountryName = cn.CountryName,
                               Phone = v.Phone,
                               Mobaile = v.Mobaile,
                               Address = v.Address,
                               State = v.State,
                               ZipCode = v.ZipCode,
                               Email = v.Email,
                               ContactPerson = v.ContactPerson,
                               Notes = v.Notes,
                               Debit = v.Debit,
                               DelFlage = v.DelFlage
                           }
                          ).ToListAsync();

            return await vendors;
        }

        // GET: api/Vendor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }

        // PUT: api/Vendor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(int id, Vendor ve)
        {
            if (id != ve.VendorId)
            {
                return BadRequest();
            }

            _context.Entry(ve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
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

        // POST: api/Vendor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor ve)
        {
            _context.Vendors.Add(ve);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendor", new { id = ve.VendorId }, ve);
        }

        // DELETE: api/Vendor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            var ve = await _context.Vendors.FindAsync(id);
            if (ve == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(ve);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorExists(int id)
        {
            return _context.Vendors.Any(e => e.VendorId == id);
        }
    }
}

