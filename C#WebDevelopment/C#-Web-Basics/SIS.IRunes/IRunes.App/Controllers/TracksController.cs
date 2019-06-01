namespace IRunes.App.Controllers
{
    using Data;
    using Extensions;
    using Models;
    using SIS.HTTP.Common;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using System.Linq;

    public class TracksController : Controller
    {
        [Authorize]
        public ActionResult Create()
        {
            var albumId = this.Request.QueryData[GlobalConstants.albumId].ToString();

            this.ViewData[GlobalConstants.AlbumId] = albumId;
            return this.View();
        }

        [Authorize]
        [HttpPost(ActionName = "Create")]
        public ActionResult CreateConfirm()
        {
            var albumId = this.Request.QueryData[GlobalConstants.albumId].ToString();

            using (var context = new RunesDbContext())
            {
                var albumFromDb = context.Albums.SingleOrDefault(album => album.Id == albumId);

                if (albumFromDb == null)
                {
                    return this.Redirect(GlobalConstants.AlbumsAllPath);
                }

                var name = ((ISet<string>)this.Request.FormData[GlobalConstants.name]).FirstOrDefault();
                var link = ((ISet<string>)this.Request.FormData[GlobalConstants.link]).FirstOrDefault();
                var price = ((ISet<string>)this.Request.FormData[GlobalConstants.price]).FirstOrDefault();

                var trackForDb = new Track
                {
                    Name = name,
                    Link = link,
                    Price = decimal.Parse(price)
                };

                albumFromDb.Tracks.Add(trackForDb);
                albumFromDb.Price = albumFromDb
                    .Tracks
                    .Select(track => track.Price)
                    .Sum() * 87 / 100;

                context.Update(albumFromDb);
                context.SaveChanges();
            }

            return this.Redirect(string.Format(GlobalConstants.AlbumsDetailsQueryIdParam, albumId));
        }

        [Authorize]
        public ActionResult Details()
        {
            var albumId = this.Request.QueryData[GlobalConstants.albumId].ToString();
            var trackId = this.Request.QueryData[GlobalConstants.trackId].ToString();

            using (var context = new RunesDbContext())
            {
                var trackFromDb = context.Tracks.SingleOrDefault(track => track.Id == trackId);

                if (trackFromDb == null)
                {
                    return this.Redirect(string.Format(GlobalConstants.AlbumsDetailsQueryIdParam, albumId));
                }

                this.ViewData[GlobalConstants.AlbumId] = albumId;
                this.ViewData[GlobalConstants.Track] = trackFromDb.ToHtmlDetails(albumId);

                return this.View();
            } 
        }
    }
}
