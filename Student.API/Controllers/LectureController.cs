using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolMangement.API.Dtos;
using SchoolMangement.API.Dtos.Course;
using SchoolMangement.API.Entities;
using Student.API.Data;

 namespace SchoolMangement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public LectureController(SchoolDbContext context)
        {
            _context = context;
        }
        [HttpPost]

        public IActionResult Post(LectureToAddDto lecturerToAdd)
        {

            var name = lecturerToAdd.DepartmentName;

            var trimmedName = name.Trim();

            var department = _context.Departments.FirstOrDefault(c => c.Name == trimmedName);


            if (department != null)
            {

                var DepartmentId = department.Id;

                //map dto to entity
                var lecturer = new Lecture
                {
                    Name = lecturerToAdd.Name,
                    Description=lecturerToAdd.Description,

                    Salary=lecturerToAdd.Salary,
                    DateOfJoin=lecturerToAdd.DateOfJoin,

                    DepartmentId = department.Id
                };

                var lecturers = _context.Lectures.Add(lecturer);


                _context.SaveChanges();

                return Ok(lecturers);

            }
            return BadRequest();
        }




        //get all
        [HttpGet]
        public IActionResult Get()
        {
            var lecturers = _context.Lectures.ToList();

            if (lecturers == null)
            {
                return NotFound();
            }
            return Ok(lecturers);
        }
        //get by id

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var lecturer = _context.Lectures.Find(id);

            if (lecturer == null) { return NotFound(); }

            return Ok(lecturer);
        }
        //put update
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(long id, Entities.Lecture lecturer)
        {
            var lecturerToUpdate = _context.Lectures.Find(id);

            if (lecturerToUpdate == null) { return NotFound(); }

            lecturerToUpdate.Name = lecturer.Name;
            lecturerToUpdate.Description = lecturer.Description;
            lecturerToUpdate.Salary = lecturer.Salary;
            lecturerToUpdate.DateOfJoin = lecturer.DateOfJoin;

            _context.SaveChanges();

            return Ok();

        }

        //delete
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            var lecturer = _context.Lectures.Find(id);

            if (lecturer == null)
            {
                return NotFound();
            }

            _context.Lectures.Remove(lecturer);

            _context.SaveChanges();

            return Ok();
        }

    }
};
