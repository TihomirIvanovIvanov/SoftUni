using FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(t => t.HomeGames)
                .WithOne(g => g.HomeTeam)
                .HasForeignKey(t => t.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(t => t.AwayGames)
                .WithOne(g => g.AwayTeam)
                .HasForeignKey(t => t.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
