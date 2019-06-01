﻿namespace IRunes.App.Controllers
{
    using Extensions;
    using Models;
    using Services;
    using SIS.HTTP.Common;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using System.Linq;

    public class TracksController : Controller
    {
        private readonly ITrackService trackService;

        private readonly IAlbumService albumService;
        public TracksController()
        {
            this.trackService = new TrackService();
            this.albumService = new AlbumService();
        }

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
            var name = ((ISet<string>)this.Request.FormData[GlobalConstants.name]).FirstOrDefault();
            var link = ((ISet<string>)this.Request.FormData[GlobalConstants.link]).FirstOrDefault();
            var price = ((ISet<string>)this.Request.FormData[GlobalConstants.price]).FirstOrDefault();

            var trackForDb = new Track
            {
                Name = name,
                Link = link,
                Price = decimal.Parse(price)
            };

            if (!this.albumService.AddTrackToAlbum(albumId, trackForDb))
            {
                return this.Redirect(GlobalConstants.AlbumsAllPath);
            }

            return this.Redirect(string.Format(GlobalConstants.AlbumsDetailsQueryIdParam, albumId));
        }

        [Authorize]
        public ActionResult Details()
        {
            var albumId = this.Request.QueryData[GlobalConstants.albumId].ToString();
            var trackId = this.Request.QueryData[GlobalConstants.trackId].ToString();

            var trackFromDb = this.trackService.GetTrackById(trackId);

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