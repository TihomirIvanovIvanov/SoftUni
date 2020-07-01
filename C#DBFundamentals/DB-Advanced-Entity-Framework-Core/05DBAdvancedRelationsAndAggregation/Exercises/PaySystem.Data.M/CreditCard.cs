using System;
using System.Collections.Generic;

namespace PaySystem.Data.M
{
    public class CreditCard
    {
        public int Id { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwed { get; set; }

        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        public DateTime ExpirationDate { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
