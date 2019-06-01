namespace IRunes.App.Controllers
{
    using Data;
    using Extensions;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using SIS.HTTP.Common;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumsController : Controller
    {
        public IHttpResponse All(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect(GlobalConstants.UsersLoginPath);
            }

            using (var context = new RunesDbContext())
            {
                ICollection<Album> allAlbums = context.Albums.ToList();

                if (allAlbums.Count == 0)
                {
                    this.ViewData[GlobalConstants.Albums] = GlobalConstants.NoAlbumsInDb;
                }
                else
                {
                    this.ViewData[GlobalConstants.Albums] =
                        string.Join(string.Empty,
                        allAlbums.Select(album => album.ToHtmlAll()).ToList());
                }

                return this.View();
            }
        }

        public IHttpResponse Create(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect(GlobalConstants.UsersLoginPath);
            }

            return this.View();
        }

        [HttpPost(ActionName = "Create")]
        public IHttpResponse CreateConfirm(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect(GlobalConstants.UsersLoginPath);
            }

            using (var context = new RunesDbContext())
            {
                var name = ((ISet<string>)httpRequest.FormData[GlobalConstants.name]).FirstOrDefault();
                var cover = ((ISet<string>)httpRequest.FormData[GlobalConstants.albumCover]).FirstOrDefault();

                var album = new Album
                {
                    Name = name,
                    Cover = cover,
                    Price = 0M
                };

                context.Albums.Add(album);
                context.SaveChanges();
            }

            return this.Redirect(GlobalConstants.AlbumsAllPath);
        }

        public IHttpResponse Details(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect(GlobalConstants.UsersLoginPath);
            }

            var albumId = httpRequest.QueryData[GlobalConstants.id].ToString();

            using (var context = new RunesDbContext())
            {
                var albumFromDb = context.Albums
                    .Include(album => album.Tracks)
                    .SingleOrDefault(album => album.Id == albumId);

                if (albumFromDb == null)
                {
                    return this.Redirect(GlobalConstants.AlbumsAllPath);
                }

                this.ViewData[GlobalConstants.Album] = albumFromDb.ToHtmlDetails();
                return this.View();
            }
        }
    }
}
