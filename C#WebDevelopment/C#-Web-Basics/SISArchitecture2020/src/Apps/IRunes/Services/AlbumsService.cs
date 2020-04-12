using IRunes.Data;
using IRunes.Models;
using IRunes.ViewModels.Albums;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext dbContext;

        public AlbumsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0.0m,
            };

            this.dbContext.Albums.Add(album);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<AlbumInfoViewModel> GetAll()
        {
            var allAlbums = this.dbContext.Albums
                .Select(album => new AlbumInfoViewModel
                {
                    Id = album.Id,
                    Name = album.Name
                }).ToList();

            return allAlbums;
        }

        public AlbumDetailsViewModel GetDetails(string id)
        {
            var album = this.dbContext.Albums
                .Where(album => album.Id == id)
                .Select(album => new AlbumDetailsViewModel
                {
                    Id = album.Id,
                    Name = album.Name,
                    Price = album.Price,
                    Cover = album.Cover,
                    Tracks = album.Tracks.Select(tracks => new TrackInfoViewModel
                    {
                        Id = tracks.Id,
                        Name = tracks.Name
                    })
                })
                .FirstOrDefault();

            return album;
        }
    }
}
