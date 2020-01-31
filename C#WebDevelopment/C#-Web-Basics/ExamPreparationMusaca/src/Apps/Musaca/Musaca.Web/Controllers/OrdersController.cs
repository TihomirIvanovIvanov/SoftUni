using Musaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace Musaca.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize]
        public IActionResult Cashout()
        {
            var orders = this.orderService.GetCurrentActiveOrderByCashierId(this.User.Id);

            this.orderService.CompleteOrderById(orders.Id, this.User.Id);

            return this.Redirect("/");
        }
    }
}
