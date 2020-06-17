using System;
using System.Collections.Generic;

namespace SalesDb.Models
{
    public class Store
    {
        public Store()
        {
            this.Sales = new List<Sale>();
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
