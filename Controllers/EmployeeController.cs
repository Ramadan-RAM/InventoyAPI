using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularERPApi.Data;
using AngularERPApi.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AngularERPApi.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EmployeeController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            /*return await _context.Employees.ToListAsync();*/

            var employees = (from e in _context.Employees
                             join d in _context.Department on e.DepartmentId equals d.DepartmentId
                             join cn in _context.Country on e.CountryId equals cn.CountryId

                             select new Employee
                             {
                                 EmployeeId = e.EmployeeId,
                                 EmployeeNumber = e.EmployeeNumber,
                                 EmployeeName = e.EmployeeName,
                                 PersoanalId = e.PersoanalId,
                                 DOB = e.DOB,
                                 HiringDate = e.HiringDate,
                                 GrossSalary = e.GrossSalary,
                                 NetSalary = e.NetSalary,
                                 DepartmentId = e.DepartmentId,
                                 DepartmentName = d.DepartmentName,
                                 CountryId = e.CountryId,
                                 CountryName = cn.CountryName,
                                 Phone = e.Phone,
                                 Mobaile = e.Mobaile,
                                 EmployeeImage = e.EmployeeImage,
                                 EmployeeResum = e.EmployeeResum,
                                 DelFlage = e.DelFlage
                             }
                        ).ToListAsync();

            return await employees;
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

           /* string uniqueFileName = UploadedImg(employee);
            string uniqueFile = UploadedFile(employee);

            employee.EmployeeImage = uniqueFileName;
            employee.EmployeeResum = uniqueFile;*/

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            /* string uniqueFileName = UploadedImg(employee);
             string uniqueFile = UploadedFile(employee);

             employee.EmployeeImage = uniqueFileName;
             employee.EmployeeResum = uniqueFile;

             _context.Attach(employee);
             _context.Entry(employee).State = EntityState.Added;
             await _context.SaveChangesAsync();
 */

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }


        [Route("SaveFileImage")]
        [HttpPost]
        public JsonResult SaveFileImage()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = webHostEnvironment.ContentRootPath + "/uploadImg/" + filename;

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

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = webHostEnvironment.ContentRootPath + "/uploadFile/" + filename;

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

        //private string UploadedImg(Employee employee)
        //{
        //    string uniqueFileName = null;
        //    if (employee.FrontImage != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploadImg");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + employee.FrontImage.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using var fileStream = new FileStream(filePath, FileMode.Create);
        //        employee.FrontImage.CopyTo(fileStream);
        //    }
        //    return uniqueFileName;
        //}


        //private string UploadedFile(Employee employee)
        //{
        //    string uniqueFileName = null;
        //    if (employee.Resum != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploadFile");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + employee.Resum.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using var fileStream = new FileStream(filePath, FileMode.Create);
        //        employee.Resum.CopyTo(fileStream);
        //    }
        //    return uniqueFileName;
        //}
    }
}
