using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Linq;

namespace PhotoShare.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly PhotoShareContext context;

        private readonly IUsersService usersService;

        private readonly IUsersSessionService usersSessionService;

        public AlbumsService(PhotoShareContext context, IUsersService usersService, IUsersSessionService usersSessionService)
        {
            this.context = context;
            this.usersService = usersService;
            this.usersSessionService = usersSessionService;
        }

        public void AddTagToAlbum(string albumName, string tagName)
        {
            var tag = this.TagByName(tagName);
            var album = this.AlbumByName(albumName);

            if (tag == null || album == null)
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            var albumOwner = this.context.Users
                .FirstOrDefault(a => a.AlbumRoles.Any(ar => ar.Album == album && ar.Role == Role.Owner));

            if (albumOwner != this.usersSessionService.User)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            this.context.AlbumTags.Add(new AlbumTag { Album = album, Tag = tag });
            this.context.SaveChanges();
        }

        public Album AlbumByName(string name)
        {
            var album = this.context.Albums
                .FirstOrDefault(a => a.Name == name);

            return album;
        }

        public Album CreateAlbum(string username, string albumTitle, string color, string[] tags)
        {
            var user = this.usersService.ByUsername(username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (!Enum.TryParse(typeof(Color), color, out object bgColor))
            {
                throw new ArgumentException($"Color {color} not found!");
            }

            var backColor = (Color)bgColor;

            if (!tags.All(t => this.TagByName(t) != null))
            {
                throw new ArgumentException("Invalid tags!");
            }

            var album = this.AlbumByName(albumTitle);

            if (album != null)
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            var albumTags = tags.Select(t => this.TagByName(t));

            album = new Album
            {
                BackgroundColor = backColor,
                Name = albumTitle,
            };

            this.context.Albums.Add(album);

            albumTags.ToList()
                .ForEach(at => this.context.AlbumTags.Add(new AlbumTag { Album = album, Tag = at }));

            this.context.AlbumRoles.Add(new AlbumRole { Album = album, User = user, Role = Role.Owner });

            this.context.SaveChanges();

            return album;
        }

        public Tag CreateTag(string name)
        {
            var tag = context.Tags.FirstOrDefault(t => t.Name == name);

            if (tag != null)
            {
                throw new ArgumentException($"Tag {tag.Name} exists!");
            }

            tag = new Tag { Name = name };

            this.context.Tags.Add(tag);
            this.context.SaveChanges();

            return tag;
        }

        public string ShareAlbum(int albumId, string username, string permission)
        {
            var album = this.context.Albums
                .FirstOrDefault(a => a.Id == albumId);

            if (album == null)
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            var isAlbumOwner = this.context.AlbumRoles
                .Any(ar => ar.Album == album && ar.Role == Role.Owner && ar.User == this.usersSessionService.User);

            if (!isAlbumOwner)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var user = this.usersService.ByUsername(username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (!Enum.TryParse(typeof(Role), permission, out object roleObj))
            {
                throw new ArgumentException("Permission must be either “Owner” or “Viewer”!");
            }

            var role = (Role)roleObj;

            this.context.AlbumRoles.Add(new AlbumRole { Album = album, Role = role });
            this.context.SaveChanges();

            return album.Name;
        }

        public Tag TagByName(string name)
        {
            var tag = this.context.Tags
                .FirstOrDefault(t => t.Name == name);

            return tag;
        }
    }
}
