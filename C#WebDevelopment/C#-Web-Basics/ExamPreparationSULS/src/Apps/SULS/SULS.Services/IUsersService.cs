using SULS.Models;

namespace SULS.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);
    }
}
