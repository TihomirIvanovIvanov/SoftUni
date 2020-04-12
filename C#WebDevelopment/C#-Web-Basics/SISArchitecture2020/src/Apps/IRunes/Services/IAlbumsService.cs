using IRunes.ViewModels.Albums;
using System.Collections.Generic;

namespace IRunes.Services
{
    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IEnumerable<AlbumInfoViewModel> GetAll();

        AlbumDetailsViewModel GetDetails(string id);
    }
}
