using System.Collections.Generic;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int MaxPoints { get; set; }

        public List<ProblemDetailsSubmissionViewModel> Submissions { get; set; }
    }
}
