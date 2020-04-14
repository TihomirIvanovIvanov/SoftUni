using Andreys.Models;
using Andreys.ViewModels.Products;
using System.Linq;

namespace Andreys.Services
{
    public interface IProductsService
    {
        int Add(ProductAddInputModel productAddInputModel);

        IQueryable<Product> GetAll();
    }
}
