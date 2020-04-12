using IRunes.Data;
using IRunes.Models;
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
                .Sum(track => track.Price);

            var album = this.dbContext.Albums.FirstOrDefault(album => album.Id == albumId);
            album.Price = allTracksPricesSum * 0.87m;

            this.dbContext.SaveChanges();
        }
    }
}
