using SULS.Models;

namespace SULS.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string password, string email);

        User GetUserOrNull(string username, string password);
    }
}
