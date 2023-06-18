namespace Student.API.Entities
{
    public class Course
    {
          public long Id { get; set; }
        public string Name { get; set; }

        public long DepartmentId { get; set; }
        public Department Department{ get; set; }
        public IList<StudentCourse> Courses { get; set; }
    }
}
