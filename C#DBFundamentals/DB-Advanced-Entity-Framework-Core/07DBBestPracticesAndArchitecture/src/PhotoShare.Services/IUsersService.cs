namespace PhotoShare.Services
{
    using PhotoShare.Models;

    public interface IUsersService
    {
        User Create(string username, string password, string confirmPassword, string email);

        User ByUsername(string username);
    }
}
