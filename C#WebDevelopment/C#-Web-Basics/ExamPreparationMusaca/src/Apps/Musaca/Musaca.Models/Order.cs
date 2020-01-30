using System;
using System.Collections.Generic;

namespace Musaca.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new List<Product>();
        }

        public string Id { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime IssuedOn { get; set; }

        public string CashierId { get; set; }

        public User Cashier { get; set; }

        public List<Product> Products { get; set; }
    }
}
