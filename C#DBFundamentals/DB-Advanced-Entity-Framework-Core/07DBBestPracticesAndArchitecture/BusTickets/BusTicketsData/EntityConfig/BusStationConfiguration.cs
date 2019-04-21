namespace BusTicketsData.EntityConfig
{
    using BT.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BusStationConfiguration : IEntityTypeConfiguration<BusStation>
    {
        public void Configure(EntityTypeBuilder<BusStation> builder)
        {
            builder.HasKey(bs => bs.BusStationId);

            builder.HasOne(bs => bs.Town)
                .WithMany(t => t.BusStations)
                .HasForeignKey(bs => bs.TownId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
