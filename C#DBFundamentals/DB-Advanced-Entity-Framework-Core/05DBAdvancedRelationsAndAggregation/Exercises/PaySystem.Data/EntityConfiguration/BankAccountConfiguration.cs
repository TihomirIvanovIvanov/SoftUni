using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaySystem.Data.M;

namespace PaySystem.Data.EntityConfiguration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .Property(ba => ba.Balance)
                .IsRequired();

            builder
                .Property(ba => ba.BankName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(ba => ba.SwiftCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder
                .HasOne(ba => ba.PaymentMethod)
                .WithOne(pm => pm.BankAccount)
                .HasForeignKey<BankAccount>(ba => ba.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
