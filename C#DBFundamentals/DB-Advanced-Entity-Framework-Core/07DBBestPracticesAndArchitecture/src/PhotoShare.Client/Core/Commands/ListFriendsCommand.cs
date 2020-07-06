namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services;
    using System;
    using System.Linq;

    public class ListFriendsCommand : ICommand
    {
        private readonly IFriendshipService friendshipService;

        public ListFriendsCommand(IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
        }

        public string Execute(string command, string[] data)
        {
            if (data.Length != 1)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            var username = data[0];

            var friends = this.friendshipService
                .ListFriends(username)
                .Select(f => $"-[{f}]");

            return friends.Count() == 0 ?
                   "No friends for this user. :(" :
                  $"Friends:{Environment.NewLine}{String.Join(Environment.NewLine, friends)}";
        }
    }
}
