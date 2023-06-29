using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMangement.API.Dtos.Course;
using SchoolMangement.API.Dtos.Departments;
using SchoolMangement.API.Entities;
using Student.API.Data;
using Student.API.Entities;
using Student.API.Migrations;

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
        public IActionResult Post(courseToAddDto courseToAdd)
        {

            var name = courseToAdd.DepartmentName;

            var trimmedName = name.Trim();

            var department = _context.Departments.FirstOrDefault(c => c.Name == trimmedName);


            if (department != null)
            {

                var DepartmentId = department.Id;

      //map dto to entity
        var course = new Student.API.Entities.Course
        {
            Name = courseToAdd.Name,

            DepartmentId = department.Id
        };

                var coursee = _context.Courses.Add(course);


                _context.SaveChanges();

                return Ok(coursee);

            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Get() { 
       var course= _context.Courses.ToList();
            if (course == null) { return NotFound(); }

            return Ok(course);
        }
        [HttpGet]
        [Route ("{id}")]
        public IActionResult Get([FromRoute]long id)
        {
          var course=  _context.Courses.Find(id);
            if(course==null) { return NotFound(); } 
            return Ok(course);

        }
        [HttpPut]
        [Route("{id}")]
       public IActionResult Put(courseToAddDto courseToAdd, [FromRoute] long id)
        {
           var course= _context.Courses.Find(id);
            if (course == null) { return NotFound(); } 
            course.Name= courseToAdd.Name;
            _context.SaveChanges();
            return Ok(course);


        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]long id)
        {
            var courseToDelete = _context.Courses.Find(id);
            if(courseToDelete == null) { return NotFound(); }
            _context.Courses.Remove(courseToDelete);
            _context.SaveChanges();
            return Ok(courseToDelete);

        }
    }
    };
