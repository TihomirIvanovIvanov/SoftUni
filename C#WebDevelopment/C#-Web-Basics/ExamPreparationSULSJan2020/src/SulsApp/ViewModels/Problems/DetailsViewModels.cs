using System.Collections.Generic;

namespace SulsApp.ViewModels.Problems
{
    public class DetailsViewModels
    {
        public string Name { get; set; }

        public IEnumerable<ProblemDetailsSubmissionViewModel> Problems { get; set; }
    }
}
