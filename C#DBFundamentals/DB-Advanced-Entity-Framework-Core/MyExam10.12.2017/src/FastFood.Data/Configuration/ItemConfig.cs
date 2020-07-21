using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Data.Configuration
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .HasIndex(i => i.Name)
                .IsUnique();

            builder
                .Property(i => i.Price)
                .IsRequired();

            builder
                .HasOne(i => i.Category)
                .WithMany(oi => oi.Items)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
