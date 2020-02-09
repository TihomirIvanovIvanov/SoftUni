using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Problems
{
    public class CreateInputModel
    {
        private const string NameErrorMsg = "Name should be between 5 and 20 characters!";

        private const string PointsErrorMsg = "Points should be between 50 and 300 score!";

        [RequiredSis]
        [StringLengthSis(5, 20, NameErrorMsg)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, PointsErrorMsg)]
        public int Points { get; set; }
    }
}
