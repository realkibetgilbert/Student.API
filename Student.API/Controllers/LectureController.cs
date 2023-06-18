using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolMangement.API.Dtos;
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
        public IActionResult Post(LectureToAddDto lectureToAddDto)
        {
            //MAP LECTURE TO ADD DTO TO LECTURE

            var lectureToAdd = new Lecture
            { 
                Name = lectureToAddDto.Name,
                Description= lectureToAddDto.Description,
                Salary = lectureToAddDto.Salary,
                DateOfJoin= DateTime.Now,   


            };



            _context.Lectures.Add(lectureToAdd);

            _context.SaveChanges();

            return Ok();
        }

        //get alll
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
}
