using FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.Configuration
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder
                .HasMany(t => t.Teams)
                .WithOne(t => t.Town)
                .HasForeignKey(t => t.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
