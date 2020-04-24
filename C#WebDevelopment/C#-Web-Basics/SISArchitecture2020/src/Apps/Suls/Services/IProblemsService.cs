using Suls.Models;

namespace Suls.Services
{
    public interface IProblemsService
    {
        void Create(string name, int points);

        Problem GetById(string id);
    }
}
