using Microsoft.EntityFrameworkCore;
using StudentSystem.Data.Configuration;
using StudentSystem.Data.Models;

namespace StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            modelBuilder.ApplyConfiguration(new CourseConfiguration());

            modelBuilder.ApplyConfiguration(new ResourceConfiguration());           

            modelBuilder.Entity<Homework>()
                .Property(r => r.Content)
                .IsRequired()
                .IsUnicode(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
