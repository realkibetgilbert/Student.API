namespace Student.API.Entities
{
    public class School
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public long CollegeId { get; set; }

        public College College { get; set; }

        public List<Department> Departments { get; set; }

    }
}
