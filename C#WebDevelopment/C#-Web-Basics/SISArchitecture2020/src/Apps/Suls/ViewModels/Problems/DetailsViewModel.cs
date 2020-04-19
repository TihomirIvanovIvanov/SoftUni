using System.Collections.Generic;

namespace Suls.ViewModels.Problems
{
    public class DetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<ProblemSubmissionsDetailsViewModel> Submissions { get; set; }
    }
}
