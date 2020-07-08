namespace PhotoShare.Services
{
    using PhotoShare.Models;

    public interface IUsersService
    {
        User Create(string username, string password, string confirmPassword, string email);

        User ByUsername(string username);

        User ModifyUser(string username, string property, string newValue);

        void Delete(string username);

        User Login(string username, string password);

        string Logout();
    }
}
