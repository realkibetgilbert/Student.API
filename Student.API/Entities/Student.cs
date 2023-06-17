namespace Student.API.Entities
{
    public class Student
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string RegistrationNumber { get; set; }
        public IList<StudentCourse> Courses { get; set; }
    }
}
