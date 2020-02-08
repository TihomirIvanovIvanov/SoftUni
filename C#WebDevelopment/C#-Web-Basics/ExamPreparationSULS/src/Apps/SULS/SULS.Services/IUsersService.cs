using SULS.Models;

namespace SULS.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string password, string email);

        User GetUserOrNull(string username, string password);
    }
}
