using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Data.Configuration
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .HasIndex(e => e.Name)
                    .IsUnique();

            builder
                .HasMany(p => p.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(p => p.PositionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
