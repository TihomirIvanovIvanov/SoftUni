using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.Web.BindingModels.Products
{
    public class ProductCreateBindingModel
    {
        private const string NameErrorMessage = "Invalid product name length! Must be between 5 and 20 symbols!";

        private const string PriceErrorMessage = "Invalid product price length! Must be greater than or equals to 0.01!";

        [RequiredSis]
        [StringLengthSis(5, 20, NameErrorMessage)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(0.01, 1.7976931348623157E+308, PriceErrorMessage)]
        public double Price { get; set; }

    }
}
