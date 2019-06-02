namespace IRunes.Services
{
    using Models;

    public interface ITrackService
    { 
        Track GetTrackById(string id);
    }
}
