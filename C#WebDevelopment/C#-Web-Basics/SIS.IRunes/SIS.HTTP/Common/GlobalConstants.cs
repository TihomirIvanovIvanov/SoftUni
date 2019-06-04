namespace SIS.HTTP.Common
{
    public class GlobalConstants
    {
        #region Routes Path

        public const string HomeRedirectPath = "/";

        public const string UsersLoginPath = "/Users/Login";

        public const string UsersRegisterPath = "/Users/Register";

        public const string AlbumsAllPath = "/Albums/All";

        #endregion

        #region Action Name Path

        public const string CreateActionPathName = "Create";

        public const string LoginActionPathName = "Login";

        public const string RegisterActionPathName = "Register";

        #endregion

        public const string ResourcesPath = "Resources/";

        public const string Location = "Location";

        public const string HttpOneProtocolFragment = "HTTP/1.1";

        public const string HttpNewLine = "\r\n";

        public const string UnsupportedHttpMethodExceptionMessage = "The HTTP method - {0} is not supported.";

        public const string InlineMimeType = "inline";

        public const string AttachmentMimeType = "attachment";

        public const string TextHtmlMimeType = "text/html; charset=utf-8";

        public const string TextPlainMimeType = "text/plain; charset=utf-8";

        public const string ApplicationJsonMimeType = "application/json";

        public const string ApplicationXmlMimeType = "application/xml";

        public const string principal = "principal";

        public const string file = "file";

        public const string authorized = "authorized";

        public const string anonymous = "anonymous";

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