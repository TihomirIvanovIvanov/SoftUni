namespace Mishmash.Services
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly MishmashDbContext context;

        public UserService(MishmashDbContext context)
        {
            this.context = context;
        }

        public User CreateUser(User user)
        {
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.context.Users
                .SingleOrDefault(user => (user.Username == username || user.Email == username) && user.Password == password);
        }

        public User GetUserById(string id)
        {
            return this.context.Users
                .Include(user => user.Channels)
                .SingleOrDefault(ch => ch.Id == id);
        }


        public bool AddFollowersInChannel(string userId, UserInChannel followersFromDb)
        {
            var channelFromDb = this.GetUserById(userId);

            if (channelFromDb == null)
            {
                return false;
            }

            channelFromDb.Channels.Add(followersFromDb);

            this.context.Update(channelFromDb);
            this.context.SaveChanges();

            return true;
        }
    }
}
