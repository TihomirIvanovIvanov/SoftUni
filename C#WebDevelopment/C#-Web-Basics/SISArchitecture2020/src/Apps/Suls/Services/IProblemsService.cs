using Suls.Models;
using System.Collections.Generic;

namespace Suls.Services
{
    public interface IProblemsService
    {
        IEnumerable<Problem> GetAll();
    }
}
