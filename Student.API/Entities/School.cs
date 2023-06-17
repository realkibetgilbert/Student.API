namespace Student.API.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Department> Departments { get; set; }

    }
}
