using SULS.Data;
using SULS.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SULS.Services
{
    public class UsersService : IUsersService
    {
        private readonly SULSContext context;

        public UsersService(SULSContext context)
        {
            this.context = context;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public User GetUserOrNull(string username, string password)
        {
            var users = this.context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == this.HashPassword(password));

            return users;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
