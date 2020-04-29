using BattleCards.ViewModels.Users;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        string GetUserId(LoginInputModel input);

        void Register(RegisterInputModel input);

        bool UsernameExists(string username);

        bool EmailExists(string email);

        string GetUsername(string id);
    }
}
