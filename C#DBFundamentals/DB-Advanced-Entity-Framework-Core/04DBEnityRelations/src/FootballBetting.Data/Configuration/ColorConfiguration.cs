using FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.Configuration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
                .HasMany(c => c.PrimaryKitTeams)
                .WithOne(c => c.PrimaryKitColor)
                .HasForeignKey(c => c.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasMany(c => c.SecondaryKitTeams)
               .WithOne(c => c.SecondaryKitColor)
               .HasForeignKey(c => c.SecondaryKitColorId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
