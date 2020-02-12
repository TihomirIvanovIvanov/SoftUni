using IRunes.App.ViewModels.Tracks;
using IRunes.Data;
using IRunes.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Linq;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;
        private readonly RunesDbContext db;

        public TracksController(ITracksService tracksService, RunesDbContext db)
        {
            this.tracksService = tracksService;
            this.db = db;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateViewModel { AlbumId = albumId };

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
                return this.Error("Track name should be between 4 and 20 characters!");
            }

            if (string.IsNullOrWhiteSpace(input.Link))
            {
                return this.Error("Link is required!");
            }

            if (input.Price < 0)
            {
                return this.Error("Price should be a positive number");
            }

            this.tracksService.Create(input.AlbumId, input.Name, input.Link, input.Price);
            return this.Redirect($"/Albums/Details?id={input.AlbumId}");
        }

        public HttpResponse Details(string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trackDetails = this.db.Tracks.Where(t => t.Id == trackId)
                .Select(t => new DetailsViewModel
                {
                    AlbumId = t.AlbumId,
                    Name = t.Name,
                    Link = t.Link,
                    Price = t.Price
                }).FirstOrDefault();

            return this.View(trackDetails);
        }
    }
}
