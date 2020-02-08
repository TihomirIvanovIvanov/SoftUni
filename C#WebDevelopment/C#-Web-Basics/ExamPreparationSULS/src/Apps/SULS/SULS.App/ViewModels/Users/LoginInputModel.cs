using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Users
{
    public class LoginInputModel
    {
        private const string UsernameErrorMsg = "Username should be between 5 and 20 characters!";

        private const string PasswordErrorMsg = "Password should be between 6 and 20 characters!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMsg)]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, PasswordErrorMsg)]
        public string Password { get; set; }
    }
}
