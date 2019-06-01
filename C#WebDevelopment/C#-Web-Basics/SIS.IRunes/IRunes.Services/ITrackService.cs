namespace IRunes.Services
{
    using Models;
    using System.Collections.Generic;

    public interface ITrackService
    { 
        Track GetTrackById(string id);
    }
}
