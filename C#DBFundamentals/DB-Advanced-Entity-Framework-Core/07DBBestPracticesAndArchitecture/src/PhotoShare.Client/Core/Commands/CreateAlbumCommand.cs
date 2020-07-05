namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class CreateAlbumCommand : ICommand
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string command, string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
