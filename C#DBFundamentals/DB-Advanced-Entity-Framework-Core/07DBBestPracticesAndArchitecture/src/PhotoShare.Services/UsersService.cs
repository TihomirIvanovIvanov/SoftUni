namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class UsersService : IUsersService
    {
        private readonly PhotoShareContext context;

        public UsersService(PhotoShareContext context)
        {
            this.context = context;
        }

        public User ByUsername(string username)
        {
            var user = this.context.Users
                .FirstOrDefault(u => u.Username == username);

            return user;
        }

        public User Create(string username, string password, string confirmPassword, string email)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            var user = this.ByUsername(username);

            if (user != null)
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }

            user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return user;
        }
    }
}
