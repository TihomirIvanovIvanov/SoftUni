using System.Collections.Generic;

namespace SalesDb.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new List<Sale>();
        }

        public int Id { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
