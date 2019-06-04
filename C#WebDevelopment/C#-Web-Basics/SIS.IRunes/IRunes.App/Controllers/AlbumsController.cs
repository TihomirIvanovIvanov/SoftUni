namespace IRunes.App.Controllers
{
    using IRunes.App.ViewModels;
    using Models;
    using Services;
    using SIS.HTTP.Common;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;

        public AlbumsController()
        {
            this.albumService = new AlbumService();
        }

        [Authorize]
        public ActionResult All()
        {
            ICollection<Album> allAlbums = this.albumService.GetAllAlbums();

            if (allAlbums.Count != 0)
            {
                return this.View(allAlbums.Select(ModelMapper.ProjectTo<AlbumAllViewModel>).ToList());
            }

            return this.View(new List<AlbumAllViewModel>());
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost(ActionName = GlobalConstants.CreateActionPathName)]
        public ActionResult CreateConfirm()
        {
            var name = ((ISet<string>)this.Request.FormData[GlobalConstants.name]).FirstOrDefault();
            var cover = ((ISet<string>)this.Request.FormData[GlobalConstants.albumCover]).FirstOrDefault();

            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0M
            };

            this.albumService.CreateAlbum(album);

            return this.Redirect(GlobalConstants.AlbumsAllPath);
        }

        [Authorize]
        public ActionResult Details()
        {
            var albumId = this.Request.QueryData[GlobalConstants.id].ToString();
            var albumFromDb = this.albumService.GetAlbumById(albumId);

            AlbumDetailsViewModel albumViewModel = ModelMapper.ProjectTo<AlbumDetailsViewModel>(albumFromDb);

            if (albumFromDb == null)
            {
                return this.Redirect(GlobalConstants.AlbumsAllPath);
            }

            return this.View(albumViewModel);
        }
    }
}
