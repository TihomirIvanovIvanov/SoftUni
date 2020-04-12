using IRunes.Data;
using IRunes.Models;
using IRunes.ViewModels.Tracks;
using System.Linq;

namespace IRunes.Services
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext dbContext;

        public TracksService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string albumId, string name, string link, decimal price)
        {
            var track = new Track
            {
                AlbumId = albumId,
                Name = name,
                Link = link,
                Price = price
            };

            this.dbContext.Tracks.Add(track);

            var allTracksPricesSum = this.dbContext.Tracks
                .Where(track => track.AlbumId == albumId)
                .Sum(track => track.Price) + price;

            var album = this.dbContext.Albums.FirstOrDefault(album => album.Id == albumId);
            album.Price = allTracksPricesSum * 0.87m;

            this.dbContext.SaveChanges();
        }

        public DetailsViewModel GetDetails(string trackId)
        {
            var track = this.dbContext.Tracks.
                Where(track => track.Id == trackId)
                .Select(track => new DetailsViewModel
                {
                    AlbumId = track.AlbumId,
                    Price = track.Price,
                    Name = track.Name,
                    Link = track.Link,
                })
                .FirstOrDefault();

            return track;
        }
    }
}
