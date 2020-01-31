using Musaca.Web.ViewModels.Products;
using System.Collections.Generic;
using System.Linq;

namespace Musaca.Web.ViewModels.Orders
{
    public class OrderHomeViewModel
    {
        public OrderHomeViewModel()
        {
            this.Products = new List<ProductHomeViewModel>();
        }

        public List<ProductHomeViewModel> Products { get; set; }

        public decimal Price => this.Products.Sum(p => p.Price);
    }
}
