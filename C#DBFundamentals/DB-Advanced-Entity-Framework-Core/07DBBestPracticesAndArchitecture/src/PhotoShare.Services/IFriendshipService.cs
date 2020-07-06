namespace PhotoShare.Services
{
    using System.Collections.Generic;

    public interface IFriendshipService
    {
        void AddFriend(string userUsername, string friendUsername);

        void AcceptFriend(string userUsername, string friendUsername);
    }
}
