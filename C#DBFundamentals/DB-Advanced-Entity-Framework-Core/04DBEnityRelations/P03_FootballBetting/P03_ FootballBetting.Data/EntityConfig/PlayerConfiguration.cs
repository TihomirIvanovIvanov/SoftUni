namespace P03_FootballBetting.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> entity)
        {
            entity.HasKey(e => e.PlayerId);

            entity.HasOne(t => t.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Position)
               .WithMany(p => p.Players)
               .HasForeignKey(p => p.PositionId)
               .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(ps => ps.PlayerStatistics)
                .WithOne(p => p.Player)
                .HasForeignKey(g => g.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
