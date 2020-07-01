using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaySystem.Data.M;

namespace PaySystem.Data.EntityConfiguration
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder
                .HasKey(pm => pm.Id);

            builder
                .HasIndex(pm => new { pm.UserId, pm.CreditCardId, pm.BankAccountId }).IsUnique();

            builder
                .Property(e => e.Type)
                .IsRequired();

            builder
                .Property(e => e.UserId)
                .IsRequired();

            builder
                .Property(e => e.CreditCardId)
                .IsRequired(false);

            builder
                .Property(e => e.BankAccountId)
                .IsRequired(false);

            builder
                .HasOne(u => u.User)
               .WithMany(p => p.PaymentMethods)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.BankAccount)
                .WithOne(p => p.PaymentMethod)
                .HasForeignKey<PaymentMethod>(b => b.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.CreditCard)
                .WithOne(p => p.PaymentMethod)
                .HasForeignKey<PaymentMethod>(c => c.CreditCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
