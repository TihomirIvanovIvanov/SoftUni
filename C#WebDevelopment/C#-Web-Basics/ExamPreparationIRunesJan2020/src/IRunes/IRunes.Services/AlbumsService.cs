using IRunes.Data;
using IRunes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly RunesDbContext db;

        public AlbumsService(RunesDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0.0m
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public IEnumerable<Album> GetAll()
        {
            var albums = this.db.Albums;
            return albums;
        }

        public Album GetDetails(string id)
        {
            var album = this.db.Albums
                .Include(a => a.Tracks)
                .FirstOrDefault(a => a.Id == id);

            return album;
        }
    }
}
