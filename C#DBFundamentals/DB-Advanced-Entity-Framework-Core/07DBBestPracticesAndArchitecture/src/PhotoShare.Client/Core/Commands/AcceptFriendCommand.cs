namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services;
    using System;

    public class AcceptFriendCommand : ICommand
    {
        private readonly IUsersSessionService usersSessionService;

        private readonly IFriendshipService friendshipService;

        public AcceptFriendCommand(IUsersSessionService usersSessionService, IFriendshipService friendshipService)
        {
            this.usersSessionService = usersSessionService;
            this.friendshipService = friendshipService;
        }

        // AcceptFriend <username1> <username2>
        public string Execute(string command, string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!this.usersSessionService.IsLoggedIn() || this.usersSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var userUsername = data[0];
            var friendUsername = data[1];

            this.friendshipService.AcceptFriend(userUsername, friendUsername);

            return $"{userUsername} accepted {friendUsername} as a friend";
        }
    }
}
