namespace P03_FootballBetting.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> entity)
        {
            entity.HasKey(e => e.BetId);

            entity.HasOne(u => u.User)
                .WithMany(b => b.Bets)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(u => u.Game)
                .WithMany(b => b.Bets)
                .HasForeignKey(u => u.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
