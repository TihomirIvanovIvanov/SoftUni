namespace IRunes.Services
{
    using Data;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class AlbumService : IAlbumService
    {
        private readonly RunesDbContext context;
        public AlbumService(RunesDbContext context)
        {
            this.context = context;
        }

        public Album CreateAlbum(Album album)
        {
            album = this.context.Albums.Add(album).Entity;
            this.context.SaveChanges();

            return album;
        }

        public ICollection<Album> GetAllAlbums()
        {
            return this.context.Albums.ToList();
        }

        public Album GetAlbumById(string id)
        {
            return this.context.Albums.Include(album => album.Tracks).SingleOrDefault(album => album.Id == id);
        }

        public bool AddTrackToAlbum(string albumId, Track trackFromDb)
        {
            var albumFromDb = this.GetAlbumById(albumId);

            if (albumFromDb == null)
            {
                return false;
            }

            albumFromDb.Tracks.Add(trackFromDb);
            albumFromDb.Price = albumFromDb.Tracks.Select(track => track.Price).Sum() * 87 / 100;

            this.context.Update(albumFromDb);
            this.context.SaveChanges();

            return true;
        }
    }
}
