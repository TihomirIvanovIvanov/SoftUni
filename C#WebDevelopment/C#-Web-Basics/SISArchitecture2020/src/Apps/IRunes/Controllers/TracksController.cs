using IRunes.Services;
using IRunes.ViewModels.Tracks;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateViewModel
            {
                AlbumId = albumId
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Create(input.AlbumId);
            }

            if (string.IsNullOrWhiteSpace(input.Link))
            {
                return this.Create(input.AlbumId);
            }

            if (input.Price < 0)
            {
                return this.Create(input.AlbumId);
            }

            this.tracksService.Create(input.AlbumId, input.Name, input.Link, input.Price);

            return this.Redirect("/Albums/Details?id=" + input.AlbumId);
        }

        public HttpResponse Details(string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trackViewModel = this.tracksService.GetDetails(trackId);

            return this.View(trackViewModel);
        }
    }
}
