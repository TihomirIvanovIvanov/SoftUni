namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services;
    using System;

    public class LogoutCommand : ICommand
    {
        private readonly IUsersSessionService usersSessionService;

        private readonly IUsersService usersService;

        public LogoutCommand(IUsersSessionService usersSessionService, IUsersService usersService)
        {
            this.usersSessionService = usersSessionService;
            this.usersService = usersService;
        }

        public string Execute(string command, string[] data)
        {
            if (data.Length != 0)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!this.usersSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You should log in first in order to logout.");
            }

            var loggedOutUsername = this.usersService.Logout();

            return $"User {loggedOutUsername} successfully logged out!";
        }
    }
}
