using Andreys.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Linq;

namespace Andreys.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var allProducts = this.productsService.GetAll().ToArray();
                return this.View(allProducts, "Home");
            }

            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
    }
}
