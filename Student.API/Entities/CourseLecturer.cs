using Student.API.Entities;

namespace SchoolMangement.API.Entities
{
    public class CourseLecturer
    {
        public long   CourseId{ get; set; }
        public Course Course { get; set; }

        public long LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}
