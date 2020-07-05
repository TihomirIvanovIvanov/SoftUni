namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services;
    using System;

    public class ModifyUserCommand : ICommand
    {
        private readonly IUsersSessionService usersSessionService;

        private readonly IUsersService usersService;

        public ModifyUserCommand(IUsersSessionService usersSessionService, IUsersService usersService)
        {
            this.usersSessionService = usersSessionService;
            this.usersService = usersService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string command, string[] data)
        {
            if (data.Length != 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!this.usersSessionService.IsLoggedIn() || this.usersSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var username = data[0];
            var property = data[1];
            var newValue = data[2];

            if (property != "Password" && property != "BornTown" && property != "CurrentTown")
            {
                throw new ArgumentException($"Property {property} not supported!");
            }

            var user = this.usersService.ModifyUser(username, property, newValue);

            return $"User {user.Username} {property} is {newValue}";
        }
    }
}
