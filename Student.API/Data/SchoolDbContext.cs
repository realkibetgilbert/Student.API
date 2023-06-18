using Microsoft.EntityFrameworkCore;
using Student.API.Entities;

namespace Student.API.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new {sc.CourseId,sc.StudentId});

            modelBuilder.Entity<College>()
                .HasMany(s=>s.SchoolList)
                .WithOne(s=>s.College)
                .HasForeignKey(s=>s.CollegeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Entities.School>()
                .HasMany(s => s.Departments)
                .WithOne(s => s.School)
                .HasForeignKey(s => s.schoolId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Courses)
                .WithOne(d => d.Department)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
                
        }

    }
}
