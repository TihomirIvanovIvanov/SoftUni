namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Data;
    using PhotoShare.Services;
    using System;

    public class AddTownCommand : ICommand
    {
        private readonly IUsersSessionService usersSessionService;

        private readonly ITownsService townsService;

        public AddTownCommand(IUsersSessionService usersSessionService, ITownsService townsService)
        {
            this.usersSessionService = usersSessionService;
            this.townsService = townsService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string command, string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!this.usersSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var townName = data[0];
            var country = data[1];

            var town = this.townsService.Create(townName, country);

            return $"Town {town.Name} was added successfully!";
        }
    }
}
