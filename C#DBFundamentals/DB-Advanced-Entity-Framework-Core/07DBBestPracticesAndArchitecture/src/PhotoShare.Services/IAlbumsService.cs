namespace PhotoShare.Services
{
    using PhotoShare.Models;

    public interface IAlbumsService
    {
        Tag CreateTag(string name);

        Album CreateAlbum(string username, string albumTitle, string color, string[] tags);

        Tag TagByName(string name);

        Album AlbumByName(string name);

        void AddTagToAlbum(string albumName, string tagName);

        string ShareAlbum(int albumId, string username, string permission);
    }
}
