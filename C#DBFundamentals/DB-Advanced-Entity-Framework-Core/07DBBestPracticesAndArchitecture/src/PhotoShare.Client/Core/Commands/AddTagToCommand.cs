namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Services;
    using System;

    public class AddTagToCommand : ICommand
    {
        private readonly IUsersSessionService usersSessionService;

        private readonly IAlbumsService albumsService;

        public AddTagToCommand(IUsersSessionService usersSessionService, IAlbumsService albumsService)
        {
            this.usersSessionService = usersSessionService;
            this.albumsService = albumsService;
        }

        // AddTagTo <albumName> <tag>
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

            var tagName = data[1].ValidateOrTransform();
            var albumName = data[0];

            this.albumsService.AddTagToAlbum(albumName, tagName);

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
