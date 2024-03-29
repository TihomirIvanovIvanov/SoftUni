﻿namespace P01_BillsPaymentSystem.Data.Models
{
    using System;

    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Limit { get; set; }
        public decimal MoneyOwed { get; set; }
        public decimal LimitLeft
        {
            get
            {
                return this.Limit - this.MoneyOwed;
            }
            set
            {
                value = this.LimitLeft;
            }
        }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}