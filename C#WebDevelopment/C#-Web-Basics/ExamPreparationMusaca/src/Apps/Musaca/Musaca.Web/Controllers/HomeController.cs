using Musaca.Services;
using Musaca.Web.ViewModels.Orders;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SIS.MvcFramework.Mapping;

namespace Musaca.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            var orderHomeViewModel = new OrderHomeViewModel();

            if (this.IsLoggedIn())
            {
                orderHomeViewModel = this.orderService
                    .GetCurrentActiveOrderByCashierId(this.User.Id).To<OrderHomeViewModel>();
            }
            return this.View(orderHomeViewModel);
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlah()
        {
            return this.Index();
        }
    }
}
