namespace Musaca.Models
{
    using Enums;
    using System;

    public class Order : BaseModel<int>
    {
        public StatusType Status { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CashierId { get; set; }

        public User Cashier { get; set; }

        public Guid? ReceiptId { get; set; }

        public Receipt Receipt { get; set; }
    }
}
