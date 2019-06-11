namespace Mishmash.Services
{
    using Models;

    public interface IUserService
    {
        User CreateUser(User user);

        User GetUserByUsernameAndPassword(string username, string password);

        bool AddFollowersInChannel(string userId, UserInChannel followersInChannel);

        User GetUserById(string id);
    }
}