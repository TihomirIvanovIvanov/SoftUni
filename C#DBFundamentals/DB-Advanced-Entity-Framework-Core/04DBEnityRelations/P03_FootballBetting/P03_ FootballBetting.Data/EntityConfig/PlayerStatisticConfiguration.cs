namespace P03_FootballBetting.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> entity)
        {
            entity.HasKey(e => new { e.PlayerId, e.GameId });

            entity.HasOne(p => p.Player)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(p => p.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Game)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(g => g.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
