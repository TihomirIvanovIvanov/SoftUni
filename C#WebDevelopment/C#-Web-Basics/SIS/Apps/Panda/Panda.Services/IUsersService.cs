using Panda.Models;

namespace Panda.Services
{
    public interface IUsersService
    {
        User CreateUser(User user);

        User GetUserByUsernameAndPassword(string username, string password);
    }
}
