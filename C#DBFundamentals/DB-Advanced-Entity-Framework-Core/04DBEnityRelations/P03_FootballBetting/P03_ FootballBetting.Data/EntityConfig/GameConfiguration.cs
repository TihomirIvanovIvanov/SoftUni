namespace P03_FootballBetting.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> entity)
        {
            entity.HasKey(e => e.GameId);

            entity.HasOne(ht => ht.HomeTeam)
                .WithMany(g => g.HomeGames)
                .HasForeignKey(ht => ht.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ht => ht.AwayTeam)
                .WithMany(g => g.AwayGames)
                .HasForeignKey(ht => ht.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);



            //entity.HasMany(ps => ps.PlayerStatistics)
            //    .WithOne(g => g.Game)
            //    .HasForeignKey(ps => ps.GameId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //entity.HasMany(b => b.Bets)
            //    .WithOne(g => g.Game)
            //    .HasForeignKey(b => b.BetId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
