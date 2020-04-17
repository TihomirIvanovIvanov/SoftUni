using Suls.Data;
using Suls.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Suls.Services
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

        public string GetUserId(string username, string password)
        {
            var hashPassword = this.Hash(password);
            var user = this.dbContext.Users
                .FirstOrDefault(user => user.Username == username && user.Password == hashPassword);

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

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password),
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
