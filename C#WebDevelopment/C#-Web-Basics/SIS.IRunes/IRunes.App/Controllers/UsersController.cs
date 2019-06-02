namespace IRunes.App.Controllers
{
    using Models;
    using Services;
    using SIS.HTTP.Common;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Action;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController()
        {
            this.userService = new UserService();
        }

        [NonAction]
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost(ActionName = GlobalConstants.LoginActionPathName)]
        public ActionResult LoginConfirm()
        {
            var username = ((ISet<string>)this.Request.FormData[GlobalConstants.username]).FirstOrDefault();
            var password = ((ISet<string>)this.Request.FormData[GlobalConstants.password]).FirstOrDefault();

            var userFromDb = this.userService.GetUserByUsernameAndPassword(username, this.HashPassword(password));

            if (userFromDb == null)
            {
                return this.Redirect(GlobalConstants.UsersLoginPath);
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return this.Redirect(GlobalConstants.HomeRedirectPath);
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost(ActionName = GlobalConstants.RegisterActionPathName)]
        public ActionResult RegisterConfirm()
        {
            var username = ((ISet<string>)this.Request.FormData[GlobalConstants.username]).FirstOrDefault();
            var password = ((ISet<string>)this.Request.FormData[GlobalConstants.password]).FirstOrDefault();
            var confirmPassword = ((ISet<string>)this.Request.FormData[GlobalConstants.confirmPassword]).FirstOrDefault();
            var email = ((ISet<string>)this.Request.FormData[GlobalConstants.email]).FirstOrDefault();

            if (password != confirmPassword)
            {
                return this.Redirect(GlobalConstants.UsersRegisterPath);
            }

            var user = new User
            {
                Username = username,
                Password = this.HashPassword(password),
                Email = email
            };

            this.userService.CreateUser(user); 

            return this.Redirect(GlobalConstants.UsersLoginPath);
        }

        public ActionResult Logout()
        {
            this.SignOut();

            return this.Redirect(GlobalConstants.HomeRedirectPath);
        }
    }
}