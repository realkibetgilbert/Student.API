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
                var CollegeId=college.Id;



                var school = new Student.API.Entities.School
                {
                    Name = schoolToAddDto.Name,
                    Description = schoolToAddDto.Description,
                    CollegeId = college.Id
                };

                var schoool = _context.Schools.Add(school);


                _context.SaveChanges();

                return Ok();
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
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] long id, SchoolToAddDto school)
        {
           var schoolToUpdate= _context.Schools.Find(id);
            if(schoolToUpdate == null) { return NotFound(); }
            schoolToUpdate.Name = school.Name;
            schoolToUpdate.Description = school.Description;

            _context.Schools.Update(schoolToUpdate);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove([FromRoute]long id)
        {
           var schoolToDelete= _context.Schools.Find(id);
            if (schoolToDelete == null) { return NotFound(); }

            _context.Schools.Remove(schoolToDelete);
            _context.SaveChanges();
            return Ok();
        }
    }
}
