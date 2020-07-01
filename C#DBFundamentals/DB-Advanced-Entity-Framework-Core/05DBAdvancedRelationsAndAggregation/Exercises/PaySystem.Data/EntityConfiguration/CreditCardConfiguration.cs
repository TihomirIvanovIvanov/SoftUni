using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaySystem.Data.M;

namespace PaySystem.Data.EntityConfiguration
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder
                .Property(cc => cc.Limit)
                .IsRequired();

            builder
                .Property(cc => cc.MoneyOwed)
                .IsRequired();

            builder
                .Property(cc => cc.ExpirationDate)
                .IsRequired();

            builder
                .Ignore(cc => cc.PaymentMethodId);

            builder
               .Ignore(cc => cc.LimitLeft);

            builder
                .HasOne(cc => cc.PaymentMethod)
                .WithOne(pm => pm.CreditCard)
                .HasForeignKey<CreditCard>(cc => cc.PaymentMethodId);
        }
    }
}
