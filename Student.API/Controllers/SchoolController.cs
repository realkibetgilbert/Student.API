using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolMangement.API.Dtos.School;
using Student.API.Data;
using Student.API.Entities;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public SchoolController(SchoolDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post(SchoolToAddDto schoolToAddDto)
        {
            var name =schoolToAddDto.CollegeName;

          var trimmedName = name.Trim();
          
            var college = _context.Colleges.FirstOrDefault(c => c.Name==trimmedName);

            if (college != null)
            {
                var collegeId=college.Id;



                var school = new Student.API.Entities.School
                {
                    Name = schoolToAddDto.Name,
                    Description = schoolToAddDto.Description,
                    CollegeId = collegeId
                };

                var schoool = _context.Schools.Add(school);


                _context.SaveChanges();

                return Ok(school);
            }
            return BadRequest();
        }

        //GET ALL
        [HttpGet]
        public IActionResult Get() 
        {
            var school = _context.Schools.ToList();

            if (school == null) { return NotFound(); }

            return Ok(school);
        }
    

        //GET BY ID

        [HttpGet]
        [Route ("{id}")]
        public IActionResult Get([FromRoute] long id) 
        {
            var school = _context.Schools.Find(id);

            if (school == null) 
            {
                return NotFound();
            };

             return Ok(school );
                
        }
        
    }
}
