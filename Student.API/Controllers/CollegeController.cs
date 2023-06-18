using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMangement.API.Dtos;
using Student.API.Data;
using Student.API.Entities;
using Student.API.Migrations;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public CollegeController(SchoolDbContext context)
        {
            _context = context;
        }
        [HttpPost]
    
        public IActionResult Post(CollegeToAddDto college)
        {
            var collegeToAdd = new College
            {
                Name = college.Name,
                Description = college.Description,

            };

            _context.Colleges.Add(collegeToAdd);

            _context.SaveChanges();

            return Ok(college);
        }

        [HttpGet]
       
        public IActionResult Get() 
        {
            var colleges = _context.Colleges.ToList();

            if (colleges == null) { return NotFound(); }

            return Ok(colleges);
        }

        [HttpGet]
        [Route("id")]

        public IActionResult Get(long id)
        {
            var college = _context.Colleges.Find(id);

            if (college== null) { return NotFound(); }

            return Ok(college);
        }
        [HttpPut]
        public IActionResult Put( long id,  CollegeToAddDto collegeToAddDto)
        {
            var collegeToUpdate = _context.Colleges.Find(id);
            if (collegeToUpdate == null) { return NotFound(); }

            collegeToUpdate.Name = collegeToAddDto.Name;
            collegeToUpdate.Description = collegeToAddDto?.Description;

            _context.SaveChanges();

            return Ok(collegeToUpdate);
           
        }
    }
}
