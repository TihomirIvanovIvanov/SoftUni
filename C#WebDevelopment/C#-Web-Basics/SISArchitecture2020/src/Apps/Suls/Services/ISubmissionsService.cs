using Suls.ViewModels.Submissions;

namespace Suls.Services
{
    public interface ISubmissionsService
    {
        CreateViewModel CreateViewModel(string problemId);

    }
}
