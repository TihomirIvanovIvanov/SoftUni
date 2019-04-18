namespace P03_FootballBetting.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasKey(e => e.CountryId);

            entity.HasMany(t => t.Towns)
                .WithOne(c => c.Country)
                .HasForeignKey(t => t.TownId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
