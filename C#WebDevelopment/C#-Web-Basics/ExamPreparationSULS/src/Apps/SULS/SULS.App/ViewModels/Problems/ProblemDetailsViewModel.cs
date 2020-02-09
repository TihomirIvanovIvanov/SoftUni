using SULS.App.ViewModels.Submissions;
using System.Collections.Generic;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemDetailsViewModel
    {
        public string Name { get; set; }

        public int MaxPoints { get; set; }

        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
