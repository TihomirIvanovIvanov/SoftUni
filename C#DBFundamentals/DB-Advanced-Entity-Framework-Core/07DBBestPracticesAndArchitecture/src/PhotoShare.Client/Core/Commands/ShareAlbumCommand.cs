namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services;
    using System;

    public class ShareAlbumCommand : ICommand
    {
        private readonly IAlbumsService albumsService;

        private readonly IUsersSessionService usersSessionService;

        public ShareAlbumCommand(IAlbumsService albumsService, IUsersSessionService usersSessionService)
        {
            this.albumsService = albumsService;
            this.usersSessionService = usersSessionService;
        }

        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string command, string[] data)
        {
            if (data.Length != 3 || !int.TryParse(data[0], out int albumId))
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!this.usersSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var username = data[1];
            var permission = data[2];

            var albumName = this.albumsService.ShareAlbum(albumId, username, permission);

            return $"Username {username} added to album {albumName} ({permission})";
        }
    }
}
