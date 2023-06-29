namespace Student.API.Entities
{
    public class College
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<School> Schools { get; set;}
        
    }
}
