namespace SIS.HTTP.Common
{
    public class GlobalConstants
    {
        #region Routes Path

        public const string HomeRedirectPath = "/";

        public const string HomeIndexPath = "/Home/Index";

        public const string UsersLoginPath = "/Users/Login";

        public const string UsersRegisterPath = "/Users/Register";

        public const string UsersLogoutPath = "/Users/Logout";

        public const string AlbumsAllPath = "/Albums/All";

        public const string AlbumsCreatePath = "/Albums/Create";

        public const string AlbumsDetailsPath = "/Albums/Details";

        public const string TracksCreatePath = "/Tracks/Create";

        public const string TracksDetailsPath = "/Tracks/Details";

        #endregion

        public const string HttpOneProtocolFragment = "HTTP/1.1";

        public const string HostHeaderKey = "Host";

        public const string HttpNewLine = "\r\n";

        public const string UnsupportedHttpMethodExceptionMessage = "The HTTP method - {0} is not supported.";

        public const string InlineResourceResult = "inline";

        public const string username = "username";

        public const string Username = "Username";

        public const string password = "password";

        public const string confirmPassword = "confirmPassword";

        public const string id = "id";

        public const string email = "email";

        public const string name = "name";

        public const string link = "link";

        public const string price = "price";

        public const string AlbumsDetailsQueryIdParam = "/Albums/Details?id={0}";

        public const string Albums = "Albums";

        public const string Album = "Album";

        public const string AlbumId = "AlbumId";

        public const string albumId = "albumId";

        public const string albumCover = "cover";

        public const string NoAlbumsInDb = "There are currently no albums.";

        public const string NoTracksInThisAlbum = "There are currently no tracks in this album.";

        public const string Track = "Track";

        public const string trackId = "trackId";

        public const string Controller = "Controller";

        public const string Views = "Views/";

        public const string Home = "Home";

        public const string HtmlSuffix = ".html";
    }
}