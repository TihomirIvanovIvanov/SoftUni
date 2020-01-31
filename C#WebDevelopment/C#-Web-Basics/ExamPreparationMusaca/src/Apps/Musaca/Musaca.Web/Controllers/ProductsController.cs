using Musaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Result;
using SIS.MvcFramework.Mapping;
using Musaca.Web.ViewModels.Products;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using Musaca.Web.BindingModels.Products;
using Musaca.Models;
using System.Linq;

namespace Musaca.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductsController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [Authorize]
        public IActionResult All()
        {
            var model = this.productService.GetAll().To<ProductsAllViewModel>().ToList();

            return this.View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ProductCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            var product = model.To<Product>();
            this.productService.CreateProduct(product);

            return this.Redirect("/Products/All");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Order(ProductOrderBindingModel model)
        {
            var productOrder = this.productService.GetByName(model.Name);

            this.orderService.AddProductToCurrentOrder(productOrder, this.User.Id);

            return this.Redirect("/");
        }
    }
}
