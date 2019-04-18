namespace P03_FootballBetting.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.UserId);

            //entity.HasMany(b => b.Bets)
            //    .WithOne(u => u.User)
            //    .HasForeignKey(b => b.BetId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
