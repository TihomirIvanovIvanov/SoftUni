using IRunes.App.ViewModels.Albums;
using IRunes.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Linq;

namespace IRunes.App.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var albums = this.albumsService.GetAll()
                .Select(a => new AlbumInfoViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                });
            var viewModel = new AllAlbumsViewModel { Albums = albums };

            return this.View(viewModel);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
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
                return this.Error("Name should be with length between 4 and 20");
            }

            if (string.IsNullOrWhiteSpace(input.Cover))
            {
                return this.Error("Cover is required.");
            }

            this.albumsService.Create(input.Name, input.Cover);
            return this.Redirect("/Albums/All");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var albumsDetails = this.albumsService.GetDetails(id);

            var viewModel = new AlbumDetailsViewModel
                {
                    Id = albumsDetails.Id,
                    Name = albumsDetails.Name,
                    Cover = albumsDetails.Cover,
                    Price = albumsDetails.Price,
                    Tracks = albumsDetails.Tracks.Select(t => new TrackInfoViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList()
                };

            return this.View(viewModel);
        }
    }
}
