using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;

namespace StudentSystem.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder
                .Property(s => s.PhoneNumber)
                .IsRequired(false)
                .HasColumnType("CHAR(10)")
                .IsUnicode(false);

            builder
                .Property(s => s.BirthDay)
                .IsRequired(false);

            builder
                .HasMany(s => s.CourseEnrollments)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(s => s.HomeworkSubmissions)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
