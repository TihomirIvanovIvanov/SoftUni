using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Data.Configuration
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .HasKey(oi => new { oi.OrderId, oi.ItemId });

            builder
                .Property(oi => oi.Quantity)
                .IsRequired();

            builder
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(oi => oi.Item)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(oi => oi.ItemId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
