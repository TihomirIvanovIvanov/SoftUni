namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class UploadPictureCommand : ICommand
    {
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string command, string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
