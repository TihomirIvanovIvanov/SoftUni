namespace Musaca.Models
{
    using System.Collections.Generic;

    public class Product : BaseModel<int>
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Barcode { get; set; }

        public string Picture { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
