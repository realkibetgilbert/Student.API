namespace Student.API.Entities
{
    public class Department
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Course> Courses { get; set; }

    }
}
