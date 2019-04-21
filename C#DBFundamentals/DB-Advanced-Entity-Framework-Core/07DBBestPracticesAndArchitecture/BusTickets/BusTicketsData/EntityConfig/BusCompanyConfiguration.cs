namespace BusTicketsData.EntityConfig
{
    using BT.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BusCompanyConfiguration : IEntityTypeConfiguration<BusCompany>
    {
        public void Configure(EntityTypeBuilder<BusCompany> builder)
        {
            builder.HasKey(b => b.BusCompanyId);

            builder.HasMany(b => b.Reviews)
                .WithOne(r => r.BusCompany)
                .HasForeignKey(r => r.ReviewId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
