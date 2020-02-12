using IRunes.Data;
using IRunes.Models;
using System.Linq;

namespace IRunes.Services
{
    public class TracksService : ITracksService
    {
        private readonly RunesDbContext db;

        public TracksService(RunesDbContext db)
        {
            this.db = db;
        }

        public void Create(string albumId, string name, string link, decimal price)
        {
            var track = new Track
            {
                AlbumId = albumId,
                Name = name,
                Link = link,
                Price = price,
            };

            this.db.Tracks.Add(track);

            var allTracksPricesSum = this.db.Tracks.Where(t => t.AlbumId == albumId)
                .Sum(t => t.Price) + price;

            var album = this.db.Albums.Find(albumId);
            album.Price = allTracksPricesSum * 0.87m;

            this.db.SaveChanges();
        }
    }
}
