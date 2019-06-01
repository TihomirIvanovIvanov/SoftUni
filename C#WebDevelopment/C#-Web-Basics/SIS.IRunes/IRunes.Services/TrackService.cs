namespace IRunes.Services
{
    using Data;
    using Models;
    using System.Linq;

    public class TrackService : ITrackService
    {
        private readonly RunesDbContext context;

        public TrackService()
        {
            this.context = new RunesDbContext();
        }

        public Track GetTrackById(string id)
        {
            return this.context.Tracks.SingleOrDefault(track => track.Id == id);
        }
    }
}
