using FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.PlayerStatistics)
                .WithOne(ps => ps.Player)
                .HasForeignKey(p => p.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
