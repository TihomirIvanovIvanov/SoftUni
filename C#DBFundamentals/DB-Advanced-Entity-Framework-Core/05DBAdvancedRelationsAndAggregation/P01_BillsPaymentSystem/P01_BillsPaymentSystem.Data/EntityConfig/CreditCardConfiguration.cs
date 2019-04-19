namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> entity)
        {
            entity.HasKey(e => e.CreditCardId);

            entity.Property(e => e.Limit)
                .IsRequired();

            entity.Property(e => e.MoneyOwed)
                .IsRequired();

            entity.Ignore(e => e.LimitLeft);

            entity.Ignore(e => e.PaymentMethodId);

            entity.Property(e => e.ExpirationDate)
                .IsRequired();
        }
    }
}
