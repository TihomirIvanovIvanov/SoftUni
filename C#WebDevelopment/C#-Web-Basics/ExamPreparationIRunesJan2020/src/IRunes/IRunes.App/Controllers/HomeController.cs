using IRunes.App.ViewModels.Home;
using IRunes.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Linq;

namespace IRunes.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = new IndexViewModel
                {
                    Username = this.usersService.GetUsername(this.User)
                };

                return this.View(viewModel, "Home");
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
