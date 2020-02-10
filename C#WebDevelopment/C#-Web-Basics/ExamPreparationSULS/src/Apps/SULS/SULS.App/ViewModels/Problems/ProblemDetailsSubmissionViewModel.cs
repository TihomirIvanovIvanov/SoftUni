using System;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemDetailsSubmissionViewModel
    {
        public string SubmissionId { get; set; }

        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
