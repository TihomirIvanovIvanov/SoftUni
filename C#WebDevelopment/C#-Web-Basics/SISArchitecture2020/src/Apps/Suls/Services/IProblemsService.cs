using Suls.Models;
using Suls.ViewModels.Problems;

namespace Suls.Services
{
    public interface IProblemsService
    {
        void Create(string name, int points);

        Problem GetById(string id);

        DetailsViewModel GetDetailsById(string problemId, string userId);
    }
}
