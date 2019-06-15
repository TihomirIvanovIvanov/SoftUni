using Panda.Models;
using System.Collections.Generic;

namespace Panda.Services
{
    public interface IUsersService
    {
        User CreateUser(User user);

        User GetUserByUsernameAndPassword(string username, string password);

        IEnumerable<string> GetUsernames();
    }
}
