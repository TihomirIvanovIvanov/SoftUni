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

        public const string authorized = "authorized";

        public const string anonymous = "anonymous";

        public const string AlbumsDetailsQueryIdParam = "/Albums/Details?id={0}";

        public const string NoAlbumsInDb = "There are currently no albums.";

        public const string NoTracksInThisAlbum = "There are currently no tracks in this album.";

        public const string Controller = "Controller";

        public const string Views = "Views/";

        public const string Home = "Home";

        public const string HtmlSuffix = ".html";
    }
}