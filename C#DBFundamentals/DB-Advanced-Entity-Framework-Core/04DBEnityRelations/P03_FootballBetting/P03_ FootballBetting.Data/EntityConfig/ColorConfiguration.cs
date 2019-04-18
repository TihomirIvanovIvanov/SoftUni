namespace P03_FootballBetting.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> entity)
        {
            entity.HasKey(e => e.ColorId);

            entity.HasMany(p => p.PrimaryKitTeams)
                .WithOne(c => c.PrimaryKitColor)
                .HasForeignKey(p => p.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(s => s.SecondaryKitTeams)
                .WithOne(c => c.SecondaryKitColor)
                .HasForeignKey(s => s.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
