using FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.PlayerStatistics)
                .WithOne(ps => ps.Game)
                .HasForeignKey(p => p.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(b => b.Bets)
                .WithOne(b => b.Game)
                .HasForeignKey(b => b.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
