using System.Collections.Generic;

namespace Andreys.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public IEnumerable<ProductsInfoViewModel> Products { get; set; }
    }
}
