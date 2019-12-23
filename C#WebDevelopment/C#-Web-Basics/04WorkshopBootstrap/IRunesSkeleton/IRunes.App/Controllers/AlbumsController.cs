using IRunes.App.Extensions;
using IRunes.Data;
using IRunes.Models;
using Microsoft.EntityFrameworkCore;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer;
using SIS.WebServer.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.App.Controllers
{
    public class AlbumsController : Controller
    {
        public IHttpResponse All(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
            {
                return this.Redirect("/Users/Login");
            }

            using (var context = new RunesDbContext())
            {
                ICollection<Album> allAlbums = context.Albums.ToList();

                if (allAlbums.Count == 0)
                {
                    this.ViewData["Albums"] = "There are currently no albums.";
                }
                else
                {
                    this.ViewData["Albums"] = string.Join(string.Empty, allAlbums.Select(album => album.ToHtmlAll()).ToList());
                }

                return this.View();
            }
        }

        public IHttpResponse Create(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [PostHttp(ActionName = "Create")]
        public IHttpResponse CreateConfirm(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
            {
                return this.Redirect("/Users/Login");
            }

            using (var context = new RunesDbContext())
            {
                var name = ((ISet<string>)httpRequest.FormData["name"]).FirstOrDefault();
                var cover = ((ISet<string>)httpRequest.FormData["cover"]).FirstOrDefault();

                var album = new Album
                {
                    Name = name,
                    Cover = cover,
                    Price = 0m
                };

                context.Albums.Add(album);
                context.SaveChanges();
            }

            return this.Redirect("/Albums/All");
        }

        public IHttpResponse Details(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
            {
                return this.Redirect("/Users/Login");
            }

            var albumId = httpRequest.QueryData["id"].ToString();

            using (var context = new RunesDbContext())
            {
                var albumFromDb = context
                    .Albums.Include(album => album.Tracks)
                    .SingleOrDefault(album => album.Id == albumId);

                if (albumFromDb == null)
                {
                    return this.Redirect("/Albums/All");
                }

                this.ViewData["Album"] = albumFromDb.ToHtmlDetails();
                return this.View();
            }
        }
    }
}
