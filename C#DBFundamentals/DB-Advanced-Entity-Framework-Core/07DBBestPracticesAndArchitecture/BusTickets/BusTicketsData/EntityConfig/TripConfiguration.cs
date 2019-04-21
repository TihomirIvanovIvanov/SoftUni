namespace BusTicketsData.EntityConfig
{
    using BT.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(tr => tr.TripId);

            builder.HasOne(tr => tr.BusCompany)
                .WithMany(bs => bs.Trips)
                .HasForeignKey(tr => tr.BusCompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
