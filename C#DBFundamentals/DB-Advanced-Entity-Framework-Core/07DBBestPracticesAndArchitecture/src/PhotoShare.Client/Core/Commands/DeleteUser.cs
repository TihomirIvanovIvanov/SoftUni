namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Data;
    using PhotoShare.Services;

    public class DeleteUser : ICommand
    {
        private readonly IUsersSessionService usersSessionService;

        private readonly IUsersService usersService;

        public DeleteUser(IUsersSessionService usersSessionService, IUsersService usersService)
        {
            this.usersSessionService = usersSessionService;
            this.usersService = usersService;
        }

        // DeleteUser <username>
        public string Execute(string command, string[] data)
        {
            if (data.Length != 1)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!this.usersSessionService.IsLoggedIn() || this.usersSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var username = data[0];

            this.usersService.Delete(username);

            return $"User {username} was deleted successfully!";
        }
    }
}
