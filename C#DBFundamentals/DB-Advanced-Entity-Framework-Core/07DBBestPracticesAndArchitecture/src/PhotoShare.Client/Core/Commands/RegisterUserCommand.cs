namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services;
    using System;

    public class RegisterUserCommand : ICommand
    {
        private readonly IUsersService usersService;

        private readonly IUsersSessionService usersSessionService;

        public RegisterUserCommand(IUsersService usersService, IUsersSessionService usersSessionService)
        {
            this.usersService = usersService;
            this.usersSessionService = usersSessionService;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string command, string[] data)
        {
            if (data.Length != 4)
            {
                throw new InvalidOperationException($"Command {command} is not valid!");
            }

            if (this.usersSessionService.IsLoggedIn())
            {
                throw new ArgumentNullException("You should logged out first!");
            }

            var username = data[0];
            var password = data[1];
            var confirmPassword = data[2];
            var email = data[3];

            var user = this.usersService.Create(username, password, confirmPassword, email);

            return "User " + user.Username + " was registered successfully!";
        }
    }
}
