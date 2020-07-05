namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Models;
    using PhotoShare.Services;
    using System;
    using System.IO;
    using System.Linq;

    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumsService albumsService;

        private readonly IUsersSessionService usersSessionService;

        public CreateAlbumCommand(IAlbumsService albumsService, IUsersSessionService usersSessionService)
        {
            this.albumsService = albumsService;
            this.usersSessionService = usersSessionService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string command, string[] data)
        {
            if (data.Length < 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!this.usersSessionService.IsLoggedIn() || this.usersSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var username = data[0];
            var albumTitle = data[1];
            var color = data[2];
            var tags = data.Skip(3).Select(t => t.ValidateOrTransform()).ToArray();

            var album = this.albumsService.CreateAlbum(username, albumTitle, color, tags);

            return $"Album {album.Name} successfully created!";
        }
    }
}
