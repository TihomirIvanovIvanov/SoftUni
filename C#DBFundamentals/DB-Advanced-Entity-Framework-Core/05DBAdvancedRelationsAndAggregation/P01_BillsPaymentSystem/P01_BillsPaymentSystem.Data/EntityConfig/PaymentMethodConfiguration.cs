namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => new { e.UserId, e.CreditCardId, e.BankAccountId })
                .IsUnique();

            entity.Property(e => e.Type)
                .IsRequired();

            entity.Property(e => e.UserId)
                .IsRequired();

            entity.Property(e => e.CreditCardId)
                .IsRequired(false);

            entity.Property(e => e.BankAccountId)
                .IsRequired(false);

            entity.HasOne(u => u.Users)
                .WithMany(p => p.PaymentMethods)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(b => b.BankAccount)
                .WithOne(p => p.PaymentMethod)
                .HasForeignKey<PaymentMethod>(b => b.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.CreditCard)
                .WithOne(p => p.PaymentMethod)
                .HasForeignKey<PaymentMethod>(c => c.CreditCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
