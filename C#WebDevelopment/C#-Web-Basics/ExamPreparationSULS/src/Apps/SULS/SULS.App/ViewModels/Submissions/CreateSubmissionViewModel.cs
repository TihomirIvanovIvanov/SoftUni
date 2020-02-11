using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Submissions
{
    public class CreateSubmissionViewModel
    {
        private const string CodeErrorMsg = "Code should be between 30 and 800 characters!";

        public string ProblemId { get; set; }

        [RequiredSis]
        [StringLengthSis(30, 800, CodeErrorMsg)]
        public string Code { get; set; }
    }
}
