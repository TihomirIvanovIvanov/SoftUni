namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class UsersService : IUsersService
    {
        private readonly PhotoShareContext context;

        private readonly IUsersSessionService usersSessionService;

        private readonly ITownsService townsService;

        public UsersService(PhotoShareContext context, IUsersSessionService usersSessionService, ITownsService townsService)
        {
            this.context = context;
            this.usersSessionService = usersSessionService;
            this.townsService = townsService;
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

        public void Delete(string username)
        {
            var user = this.ByUsername(username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if ((bool)user.IsDeleted)
            {
                throw new InvalidOperationException($"User {user.Username} is already deleted!");
            }

            user.IsDeleted = true;

            this.context.SaveChanges();
        }

        public User ModifyUser(string username, string property, string newValue)
        {
            var user = this.ByUsername(this.usersSessionService.User.Username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            switch (property)
            {
                case "Password":

                    if (!(newValue.Any(ch => Char.IsLower(ch)) && newValue.Any(ch => Char.IsDigit(ch))))
                    {
                        throw new ArgumentException($"Value {newValue} not valid. Invalid Password!");
                    }

                    user.Password = newValue;
                    break;

                case "BornTown":

                    var town = this.townsService.ByName(newValue);

                    if (town == null)
                    {
                        throw new ArgumentException($"Value {newValue} not valid. Town {newValue} not found!");
                    }

                    user.BornTown = town;
                    break;

                case "CurrentTown":

                    town = this.townsService.ByName(newValue);

                    if (town == null)
                    {
                        throw new ArgumentException($"Value {newValue} not valid. Town {newValue} not found!");
                    }

                    user.CurrentTown = town;
                    break;
            }

            this.context.SaveChanges();

            return user;
        }
    }
}
