using IRunes.Services;
using IRunes.ViewModels.Albums;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.Controllers
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
            return this.View();
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel input)
        {
            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Create();
            }

            if (string.IsNullOrWhiteSpace(input.Cover))
            {
                return this.Create();
            }

            this.albumsService.Create(input.Name, input.Cover);
            return this.All();
        }

        public HttpResponse Details()
        {
            return this.View();
        }
    }
}
