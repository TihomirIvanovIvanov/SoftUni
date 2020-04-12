using IRunes.Data;
using IRunes.Models;

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
    }
}
