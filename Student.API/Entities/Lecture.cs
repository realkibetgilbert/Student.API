using Student.API.Entities;

namespace SchoolMangement.API.Entities
                                                                                                
{
    public class Lecture
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Salary { get; set; }

        public DateTime DateOfJoin { get; set; }
        public long CollegeId { get; set; }
        public College College { get; set; }
        public IList<CourseLecturer> Courses { get; set; }

    }
}
