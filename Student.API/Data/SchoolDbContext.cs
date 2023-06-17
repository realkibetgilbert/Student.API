using Microsoft.EntityFrameworkCore;
using Student.API.Entities;

namespace Student.API.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Studentt> Students { get; set; }

    }
}
