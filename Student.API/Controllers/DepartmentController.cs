using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolMangement.API.Dtos.Departments;
using SchoolMangement.API.Dtos.School;
using Student.API.Data;
using Student.API.Entities;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly SchoolDbContext _schoolDbContext;


        public DepartmentController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        [HttpPost]
        public IActionResult Post(DepartmentToAddDto departmentToAddDto)
        {
            var name = departmentToAddDto.SchoolName;

            var trimmedName = name.Trim();

            var school = _schoolDbContext.Schools.FirstOrDefault(c => c.Name == trimmedName);

            if (school != null)
            {
                var SchoolId = school.Id;


               //map Dto to  Department entity
                var department = new Department
                {
                    Name = departmentToAddDto.Name,
                    Description = departmentToAddDto.Description,
                    SchoolId = school.Id
                };

                var departmentt = _schoolDbContext.Departments.Add(department);


                _schoolDbContext.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var departmentt = _schoolDbContext.Departments.ToList();
            if (departmentt == null) { return NotFound(); }

            return Ok(departmentt);

        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            var departmentt = _schoolDbContext.Departments.Find(id);
            if (departmentt == null) { return NotFound(); }
            return Ok(departmentt);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] long id, DepartmentToAddDto departmentToUpdate)
        {
            var departmentt = _schoolDbContext.Departments.Find(id);
            if (departmentt == null) { return NotFound(); }
            departmentt.Name = departmentToUpdate.Name;
            departmentt.Description = departmentToUpdate.Description;
            
            _schoolDbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var departmentToDelete = _schoolDbContext.Departments.Find(id);

            if (departmentToDelete == null)
            {
                return NotFound();
            };
            _schoolDbContext.Departments.Remove(departmentToDelete);

            _schoolDbContext.SaveChanges();

            return Ok(departmentToDelete);
        }
    }
}
