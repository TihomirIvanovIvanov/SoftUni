using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.Web.BindingModels.Products
{
    public class ProductOrderBindingModel
    {
        [RequiredSis]
        public string Product { get; set; }
    }
}
