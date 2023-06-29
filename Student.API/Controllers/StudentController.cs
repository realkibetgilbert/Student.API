using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolMangement.API.Dtos.Student;
using Student.API.Migrations;
using System.Reflection.Metadata.Ecma335;

namespace Student.API.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolDbContext _dbContext;

        public StudentController(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult Post(studentToAddDto studentToAdd)
        {
            var name = studentToAdd.CourseName;
            var trimmedName = name.Trim();

            var course = _dbContext.Courses.FirstOrDefault(c => c.Name ==trimmedName);
            if (course != null)

            {
                var CourseId = course.Id;
                //map Dto to entity
                var student = new Entities.Student()
                {
                    FirstName = studentToAdd.FirstName,
                    LastName = studentToAdd.LastName,
                    DateOfJoin = studentToAdd.DateOfJoin,
                    RegistrationNumber = studentToAdd.RegistrationNumber,
                    CourseId = course.Id

                };

                var studentt = _dbContext.Students.Add(student);

                _dbContext.SaveChanges();

                return Ok(studentt);
            }

            return BadRequest();

        }

        [HttpGet]
        public IActionResult Get()
        {
            var studentList = _dbContext.Students.ToList();
            if (studentList == null)
            {
                return NotFound();
            }
            return Ok(studentList);

        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var student = _dbContext.Students.Find(id);

            if (student == null) { return NotFound(); }

            return Ok(student);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(long id, Entities.Student student)
        {
            var studentToUpdate = _dbContext.Students.Find(id);
            if (studentToUpdate == null) { return NotFound(); }

            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.DateOfJoin = student.DateOfJoin;
            studentToUpdate.RegistrationNumber = student.RegistrationNumber;

            _dbContext.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            var student = _dbContext.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            _dbContext.Students.Remove(student);

            _dbContext.SaveChanges();

            return Ok();
        }
    }

    };


