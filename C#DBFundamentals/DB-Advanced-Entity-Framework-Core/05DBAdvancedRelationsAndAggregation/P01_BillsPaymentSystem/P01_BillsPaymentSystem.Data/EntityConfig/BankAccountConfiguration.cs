namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> entity)
        {
            entity.HasKey(e => e.BankAccountId);

            entity.Property(e => e.Balance).IsRequired();

            entity.Ignore(e => e.PaymentMethodId);

            entity.Property(e => e.BankName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            entity.Property(e => e.SwiftCode)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
