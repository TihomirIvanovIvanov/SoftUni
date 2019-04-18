using Microsoft.EntityFrameworkCore;

using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=.;Database=StudentSystem;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>(entity =>
            {
                entity
               .Property(p => p.Name)
               .HasMaxLength(100)
               .IsUnicode(true);

                entity
                    .Property(p => p.PhoneNumber)
                    .HasColumnType("CHAR(10)")
                    .IsUnicode(false)
                    .IsRequired(false);

                entity
                    .Property(p => p.Birthday)
                    .IsRequired(false);

                entity
                    .HasMany(s => s.HomeworkSubmissions)
                    .WithOne(h => h.Student)
                    .HasForeignKey(h => h.StudentId);

                entity
                    .ToTable("Students");
            });

            builder.Entity<Course>(entity =>
            {
                entity
                .Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode(true);

                entity
                    .Property(p => p.Description)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity
                    .HasMany(c => c.Resources)
                    .WithOne(r => r.Course)
                    .HasForeignKey(r => r.CourseId);

                entity
                    .HasMany(c => c.HomeworkSubmissions)
                    .WithOne(hm => hm.Course)
                    .HasForeignKey(hm => hm.CourseId);

                entity
                    .ToTable("Courses");
            });

            builder.Entity<Resource>(entity =>
            {
                entity
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

                entity
                    .Property(p => p.Url)
                    .IsUnicode(false);

                entity
                    .ToTable("Resources");
            });

            builder.Entity<Homework>(entity =>
            {
                entity
                .Property(p => p.Content)
                .IsUnicode(false);

                entity
                    .ToTable("HomeworkSubmissions");
            });

            builder.Entity<StudentCourse>(entity =>
            {
                entity
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity
                    .HasOne(sc => sc.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(sc => sc.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(sc => sc.Course)
                    .WithMany(s => s.StudentsEnrolled)
                    .HasForeignKey(sc => sc.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .ToTable("StudentCourses");
            });
        }
    }
}
