namespace P03_FootballBetting.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> entity)
        {
            entity.HasKey(e => e.TeamId);

            entity.HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(pc => pc.PrimaryKitColor)
                .WithMany(t => t.PrimaryKitTeams)
                .HasForeignKey(pc => pc.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(sec => sec.SecondaryKitColor)
                .WithMany(t => t.SecondaryKitTeams)
                .HasForeignKey(sec => sec.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            //entity.HasMany(p => p.Players)
            //    .WithOne(t => t.Team)
            //    .HasForeignKey(p => p.PlayerId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
