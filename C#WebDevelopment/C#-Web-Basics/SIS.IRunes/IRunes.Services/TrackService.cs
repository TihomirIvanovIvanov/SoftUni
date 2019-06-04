namespace IRunes.Services
{
    using Data;
    using Models;
    using System.Linq;

    public class TrackService : ITrackService
    {
        private readonly RunesDbContext context;

        public TrackService(RunesDbContext context)
        {
            this.context = context;
        }

        public Track GetTrackById(string id)
        {
            return this.context.Tracks.SingleOrDefault(track => track.Id == id);
        }
    }
}
