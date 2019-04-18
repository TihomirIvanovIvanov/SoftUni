namespace P03_FootballBetting.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> entity)
        {
            entity.HasKey(e => e.TownId);

            //entity.HasMany(t => t.Teams)
            //    .WithOne(t => t.Town)
            //    .HasForeignKey(t => t.TeamId)
            //    .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Country)
                .WithMany(t => t.Towns)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
