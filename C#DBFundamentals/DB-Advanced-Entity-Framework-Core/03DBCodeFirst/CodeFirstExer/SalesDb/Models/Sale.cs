﻿using System;

namespace SalesDb.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CustumerId { get; set; }

        public Customer Customer { get; set; }

        public int StoreId { get; set; }

        public Store Store { get; set; }
    }
}