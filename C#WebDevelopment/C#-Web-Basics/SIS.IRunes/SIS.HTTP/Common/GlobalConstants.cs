namespace SIS.HTTP.Common
{
    public class GlobalConstants
    {
        #region Routes Path

        public const string HomeRedirectPath = "/";

        public const string HomeIndexPath = "/Home/Index";

        public const string UsersLoginPath = "/Users/Login";

        public const string UsersRegisterPath = "/Users/Register";

        public const string UsersLogoutPath = "/Users/Logout";

        #endregion

        public const string HttpOneProtocolFragment = "HTTP/1.1";

        public const string HostHeaderKey = "Host";

        public const string HttpNewLine = "\r\n";

        public const string UnsupportedHttpMethodExceptionMessage = "The HTTP method - {0} is not supported.";

        public const string username = "username";

        public const string Username = "Username";

        public const string password = "password";

        public const string confirmPassword = "confirmPassword";

        public const string id = "id";

        public const string email = "email";

        public const string Controller = "Controller";

        public const string Views = "Views/";

        public const string Home = "Home/";

        public const string HtmlSuffix = ".html";
    }
}