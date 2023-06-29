namespace SchoolMangement.API.Dtos.Student
{
    public class studentToAddDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string RegistrationNumber { get; set; }
        public string CourseName { get; set; }
    }
}
