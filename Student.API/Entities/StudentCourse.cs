namespace Student.API.Entities
{
    public class StudentCourse
    {
        public long StudentId { get; set; }
        public Student Student{ get; set; }
        
        public long CourseId { get; set; }
        public Course Course { get; set; }

    }
}
