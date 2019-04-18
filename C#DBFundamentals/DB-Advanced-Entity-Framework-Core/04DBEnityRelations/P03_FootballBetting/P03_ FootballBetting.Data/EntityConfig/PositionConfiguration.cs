namespace P03_FootballBetting.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> entity)
        {
            entity.HasKey(e => e.PositionId);

            //entity.HasMany(p => p.Players)
            //    .WithOne(p => p.Position)
            //    .HasForeignKey(p => p.PlayerId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
