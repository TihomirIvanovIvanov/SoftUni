namespace SharedTrip.Services
{
    public interface IUsersService
    {
        void Register(string username, string email, string password);

        string GetUserId(string username, string password);
    }
}
