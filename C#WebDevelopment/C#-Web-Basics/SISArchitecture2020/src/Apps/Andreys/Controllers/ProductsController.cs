using Andreys.Services;
using Andreys.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductAddInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Add();
            }

            var productId = this.productsService.Add(input);

            return this.Redirect("/");
        }
    }
}
