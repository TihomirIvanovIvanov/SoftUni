namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Data;
    using Utilities;
    using PhotoShare.Services;
    using System;

    public class AddTagCommand : ICommand
    {
        private readonly IAlbumsService albumsService;

        private readonly IUsersSessionService usersSessionService;

        public AddTagCommand(IAlbumsService albumsService, IUsersSessionService usersSessionService)
        {
            this.albumsService = albumsService;
            this.usersSessionService = usersSessionService;
        }

        // AddTag <tag>
        public string Execute(string command, string[] data)
        {
            if (data.Length != 1)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            var name = data[0].ValidateOrTransform();

            if (!this.usersSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var tag = this.albumsService.CreateTag(name);

            return $"Tag {tag.Name} was added successfully!";
        }
    }
}
