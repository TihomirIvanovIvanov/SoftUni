using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        public string Customer { get; set; }

        public DateTime DateTime { get; set; }

        public OrderType Type { get; set; }

        public decimal TotalPrice => 
            this.OrderItems.Count > 0 ?
            this.OrderItems.Select(oi => oi.Item.Price * oi.Quantity).Sum() :
            0;

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}