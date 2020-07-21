using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Data.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Custumer)
                .IsRequired();

            builder
                .Property(o => o.DateTime)
                .IsRequired();

            builder
                .Property(o => o.Type)
                .IsRequired();

            builder
                .Property(o => o.TotalPrice)
                .IsRequired();

            builder
                .Ignore(o => o.TotalPrice);

            builder
                .HasOne(o => o.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EmployeeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
