using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaySystem.Data.M;

namespace PaySystem.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            builder
                 .Property(u => u.LastName)
                 .HasMaxLength(50)
                 .IsRequired()
                 .IsUnicode();

            builder
                 .Property(u => u.Email)
                 .HasMaxLength(80)
                 .IsRequired()
                 .IsUnicode(false);

            builder
                 .Property(u => u.Password)
                 .HasMaxLength(25)
                 .IsRequired()
                 .IsUnicode(false);

            builder
                .HasMany(u => u.PaymentMethods)
                .WithOne(pm => pm.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
