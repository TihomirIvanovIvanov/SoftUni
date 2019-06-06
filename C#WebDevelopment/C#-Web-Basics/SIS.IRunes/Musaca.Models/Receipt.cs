namespace Musaca.Models
{
    using System;
    using System.Collections.Generic;

    public class Receipt : BaseModel<Guid>
    {
        public Receipt()
        {
            this.Orders = new HashSet<Order>();
        }

        public DateTime IssuedOn { get; set; }

        public int CashierId { get; set; }

        public User Cashier { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
