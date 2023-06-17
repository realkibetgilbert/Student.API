using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.API.Entities;

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
        public IActionResult Post(Studentt student)
        {
            var studentt = _dbContext.Students.Add(student);

            _dbContext.SaveChanges();

            return Ok();

        }
        [HttpGet]
        public IActionResult Get() 
        { 
            var studentList= _dbContext.Students.ToList();
            if (studentList==null)
            {
                return NotFound();
            }
            return Ok(studentList); 
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute]long id)
        {
            var student= _dbContext.Students.Find(id);

            if(student==null) { return  NotFound(); }   

            return Ok(student);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(long id,Studentt student) 
        {
            var studentToUpdate = _dbContext.Students.Find(id);
            if(studentToUpdate==null) { return NotFound();}

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

            if(student==null) { return NotFound();
            }

            _dbContext.Students.Remove(student);

            _dbContext.SaveChanges();

            return Ok();
        }

    }
}
