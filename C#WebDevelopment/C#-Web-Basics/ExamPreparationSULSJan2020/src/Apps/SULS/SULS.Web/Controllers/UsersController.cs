using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.Web.ViewModels.Users;

namespace SULS.App.Controllers
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
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters.");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters.");
            }

            var user = this.usersService.GetUserOrNull(input.Username, input.Password);

            if (user == null)
            {
                return Redirect("/Users/Login");
            }

            this.SignIn(user.Id);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters.");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Confirm password should be the same like password.");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters.");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/users/login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}