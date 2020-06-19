using FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.Configuration
{
    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder
                .HasKey(ps => new { ps.PlayerId, ps.GameId });

            builder
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(ps => ps.Game)
               .WithMany(p => p.PlayerStatistics)
               .HasForeignKey(ps => ps.GameId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
