using SIS.HTTP;
using SIS.MvcFramework;
using BattleCards.Services;
using BattleCards.ViewModels.Users;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input);

            if (userId == null)
            {
                return this.Login();
            }

            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Register();
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Register();
            }

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Register();
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Register();
            }

            if (this.usersService.EmailExists(input.Email))
            {
                return this.Register();
            }

            if (this.usersService.UsernameExists(input.Username))
            {
                return this.Register();
            }

            this.usersService.Register(input);
            return this.Login();
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}