using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Users;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BattleCards.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;

        public UsersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool EmailExists(string email)
        {
            var emailExist = this.dbContext.Users.Any(user => user.Email == email);
            return emailExist;
        }

        public string GetUserId(LoginInputModel input)
        {
            var hashPassword = this.Hash(input.Password);
            var user = this.dbContext.Users
                .FirstOrDefault(user => user.Username == input.Username && user.Password == hashPassword);

            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public string GetUsername(string id)
        {
            var username = this.dbContext.Users
                .Where(user => user.Id == id)
                .Select(user => user.Username)
                .FirstOrDefault();

            return username;
        }

        public void Register(RegisterInputModel input)
        {
            var hashPassword = this.Hash(input.Password);

            var user = new User
            {
                Username = input.Username,
                Email = input.Email,
                Password = hashPassword,
            };

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();
        }

        public bool UsernameExists(string username)
        {
            var usernameExist = this.dbContext.Users.Any(user => user.Username == username);
            return usernameExist;
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
