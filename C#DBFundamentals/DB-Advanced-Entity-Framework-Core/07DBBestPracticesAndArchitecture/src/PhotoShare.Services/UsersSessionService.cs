namespace PhotoShare.Services
{
    using PhotoShare.Models;

    public class UsersSessionService : IUsersSessionService
    {
        public User User { get; set; }

        public bool IsLoggedIn() => this.User != null;
    }
}
