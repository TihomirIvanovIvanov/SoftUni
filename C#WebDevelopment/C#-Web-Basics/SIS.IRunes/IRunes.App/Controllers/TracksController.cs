namespace IRunes.App.Controllers
{
    using IRunes.App.ViewModels.Tracks;
    using Models;
    using Services;
    using SIS.HTTP.Common;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Result;
    using ViewModels;

    public class TracksController : Controller
    {
        private readonly ITrackService trackService;

        private readonly IAlbumService albumService;
        public TracksController(ITrackService trackService, IAlbumService albumService)
        {
            this.trackService = trackService;
            this.albumService = albumService;
        }

        [Authorize]
        public ActionResult Create(string albumId)
        {
            return this.View(new TrackCreateViewModel { AlbumId = albumId });
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateInputModel model)
        {
            var trackForDb = new Track
            {
                Name = model.Name,
                Link = model.Link,
                Price = model.Price
            };

            if (!this.albumService.AddTrackToAlbum(model.AlbumId, trackForDb))
            {
                return this.Redirect(GlobalConstants.AlbumsAllPath);
            }

            return this.Redirect(string.Format(GlobalConstants.AlbumsDetailsQueryIdParam, model.AlbumId));
        }

        [Authorize]
        public ActionResult Details(string albumId, string trackId)
        {
            var trackFromDb = this.trackService.GetTrackById(trackId);

            if (trackFromDb == null)
            {
                return this.Redirect(string.Format(GlobalConstants.AlbumsDetailsQueryIdParam, albumId));
            }

            TrackDetailsViewModel trackDetailsViewModel = ModelMapper.ProjectTo<TrackDetailsViewModel>(trackFromDb);
            trackDetailsViewModel.AlbumId = albumId;

            return this.View(trackDetailsViewModel);
        }
    }
}