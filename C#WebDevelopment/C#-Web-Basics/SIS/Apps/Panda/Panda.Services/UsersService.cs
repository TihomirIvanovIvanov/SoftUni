using Panda.Data;
using Panda.Models;
using System.Collections.Generic;
using System.Linq;

namespace Panda.Services
{
    public class UsersService : IUsersService
    {
        private readonly PandaDbContext context;

        public UsersService(PandaDbContext pandaDbContext)
        {
            this.context = pandaDbContext;
        }

        public User CreateUser(User user)
        {
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.context.Users.SingleOrDefault(user => user.Username == username && user.Password == password);
        }

        public IEnumerable<string> GetUsernames()
        {
            return this.context.Users.Select(x => x.Username).ToList();
        }
    }
}
