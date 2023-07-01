using Microsoft.EntityFrameworkCore;
using SchoolMangement.API.Entities;
using Student.API.Entities;

namespace Student.API.Data
{
    public class SchoolDbContext : DbContext
    {
        internal static object Entities;

        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<College> Colleges { get; set; }

        
        public DbSet<Entities.School> Schools { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Entities.Student> Students { get; set; }
       
       

        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<CourseLecturer> CourseLecturers { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.CourseId, sc.StudentId });

            modelBuilder.Entity<CourseLecturer>().HasKey(sc => new { sc.CourseId, sc.LectureId });

            //modelBuilder.Entity<StudentCourse>().HasNoKey();

            //modelBuilder.Entity<CourseLecturer>().HasNoKey();

            modelBuilder.Entity<College>().HasMany(S => S.Schools).WithOne(C => C.College);

            modelBuilder.Entity<Entities.School>().HasOne(C => C.College).WithMany(S => S.Schools);

            modelBuilder.Entity<Department>().HasMany(C => C.Courses).WithOne(D => D.Department);

            modelBuilder.Entity<College>().HasMany(C => C.Lectures).WithOne(D => D.College);

            modelBuilder.Entity<Entities.Course>().HasMany(C => C.Students).WithOne(D => D.Course);
        }


    }

}
