using Andreys.ViewModels.Products;

namespace Andreys.Services
{
    public interface IProductsService
    {
        int Add(ProductAddInputModel productAddInputModel);
    }
}
