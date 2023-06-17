namespace Student.API.Entities
{
    public class Course
    {
          public long Id { get; set; }
        public string Name { get; set; }

        public IList<StudentCourse> Courses { get; set; }
    }
}
