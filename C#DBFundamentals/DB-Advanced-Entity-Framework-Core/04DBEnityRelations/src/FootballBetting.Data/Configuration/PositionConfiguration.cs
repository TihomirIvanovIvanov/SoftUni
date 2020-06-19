using FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder
                .HasMany(p => p.Players)
                .WithOne(p => p.Position)
                .HasForeignKey(p => p.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
