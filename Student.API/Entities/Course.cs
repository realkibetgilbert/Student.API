using SchoolMangement.API.Entities;

namespace Student.API.Entities
{
    public class Course
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Student> Students { get; set; }
        public List<Lecture> Lectures { get; set; }
        public IList<CourseLecturer> courseLecturers { get; set; }
        public IList<StudentCourse> studentCourses  { get; set; }

}
}
