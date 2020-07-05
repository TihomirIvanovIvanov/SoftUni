namespace PhotoShare.Services
{
    using PhotoShare.Models;

    public interface IUsersSessionService
    {
        User User { get; set; }

        bool IsLoggedIn();
    }
}
