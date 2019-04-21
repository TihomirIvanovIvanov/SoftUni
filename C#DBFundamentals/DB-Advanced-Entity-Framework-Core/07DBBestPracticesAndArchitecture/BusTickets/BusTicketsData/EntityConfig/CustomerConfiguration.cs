namespace BusTicketsData.EntityConfig
{
    using BT.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder.HasOne(c => c.HomeTown)
                .WithMany(ht => ht.Customers)
                .HasForeignKey(c => c.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.Reviews)
                .WithOne(c => c.Customer)
                .HasForeignKey(r => r.ReviewId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
