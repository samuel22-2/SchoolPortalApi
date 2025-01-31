using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolPortalApi.Models;

namespace SchoolPortalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly TestContext _context;

        public AdminController(TestContext context)
        {
            _context = context;
        }


        [HttpPost("AddFaculty")]
        public async Task<IActionResult> Postfaculty([FromForm] SchoolDto admin)
        {
            var fac = new School()
            {
                
                SchoolName = admin.SchoolName,

            };
            _context.Schools.Add(fac); // add what is coming from te api view
            int isSvaed = await _context.SaveChangesAsync(); // save
            if (isSvaed == 1) // check if it saved
            {
                return Ok(new
                {
                    message = "New School added successfully", // return this message
                    School = admin.SchoolName,
                    statusCode = 200
                });
            }
            return BadRequest(new
            {
                message = "failed to Add new School"



            });
        }

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> Postdepartment([FromForm] DepartmentDto dept)
        {
            var dep = new Department()
            {
                DepartmentName = dept.DepartmentName,
                SchoolId = dept.SchoolId

            };
            _context.Departments.Add(dep); // add what is coming from te api view
            int isSvaed = await _context.SaveChangesAsync(); // save
            if (isSvaed == 1) // check if it saved
            {
                return Ok(new
                {
                    message = "New Department added successfully", // return this message
                    department = dept.DepartmentName,
                    statusCode = 200
                });
            }
            return BadRequest(new
            {
                message = "failed to Add new Department"



            });
        }

    }
}
