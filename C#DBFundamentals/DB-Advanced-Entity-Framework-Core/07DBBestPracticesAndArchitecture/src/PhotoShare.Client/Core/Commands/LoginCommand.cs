namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services;
    using System;

    public class LoginCommand : ICommand
    {
        private readonly IUsersService usersService;

        private readonly IUsersSessionService usersSessionService;

        public LoginCommand(IUsersService usersService, IUsersSessionService usersSessionService)
        {
            this.usersService = usersService;
            this.usersSessionService = usersSessionService;
        }

        public string Execute(string command, string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!this.usersSessionService.IsLoggedIn())
            {
                throw new ArgumentException("You should logout first!");
            }

            var username = data[0];
            var password = data[1];

            var user = this.usersService.Login(username, password);

            return $"User {user.Username} successfully logged in!";
        }
    }
}
