namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services;
    using System;

    public class UploadPictureCommand : ICommand
    {
        private readonly IAlbumsService albumsService;

        private readonly IUsersSessionService usersSessionService;

        public UploadPictureCommand(IAlbumsService albumsService, IUsersSessionService usersSessionService)
        {
            this.albumsService = albumsService;
            this.usersSessionService = usersSessionService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string command, string[] data)
        {
            if (data.Length != 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (this.usersSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var albumName = data[0];
            var pictureTitle = data[1];
            var picturePath = data[2];

            this.albumsService.AddPicture(albumName, pictureTitle, picturePath);

            return $"Picture {pictureTitle} added to {albumName}!";
        }
    }
}
