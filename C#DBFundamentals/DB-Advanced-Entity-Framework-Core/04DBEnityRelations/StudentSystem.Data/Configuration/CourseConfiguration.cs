using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;

namespace StudentSystem.Data.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                 .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode();

            builder
                .Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode();

            builder
                .HasMany(c => c.StudentsEnrolled)
                .WithOne(s => s.Course)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(c => c.Resources)
                .WithOne(s => s.Course)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(c => c.HomeworkSubmissions)
                .WithOne(s => s.Course)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
