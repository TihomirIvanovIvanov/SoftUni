namespace Andreys.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        bool UsernameExists(string username);

        bool EmailExists(string email);

        string GetUsername(string id);

        void CreateUser(string username, string email, string password);

        void ChangePassword(string username, string newPassword);

        int CountUsers();
    }
}
