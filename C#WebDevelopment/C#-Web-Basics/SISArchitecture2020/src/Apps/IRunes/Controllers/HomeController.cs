using IRunes.Services;
using IRunes.ViewModels.Home;
using SIS.HTTP;
using SIS.MvcFramework;

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
                var indexViewModel = new IndexViewModel
                {
                    Username = this.usersService.GetUsername(this.User),
                };

                return this.View(indexViewModel, "Home");
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
