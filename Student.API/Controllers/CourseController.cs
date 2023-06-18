using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.API.Data;
using Student.API.Entities;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public CourseController(SchoolDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post(Course course) 
        { 
          return Ok(course);
        }
    }
}
