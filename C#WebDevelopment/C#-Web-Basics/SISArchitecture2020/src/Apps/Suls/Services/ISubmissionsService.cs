using Suls.ViewModels.Submissions;

namespace Suls.Services
{
    public interface ISubmissionsService
    {
        CreateViewModel CreateViewModel(string problemId);

        void Create(string problemId, string userId, string code);

        void DeleteById(string id);
    }
}
