using Andreys.Models;
using Andreys.ViewModels.Products;
using System.Linq;

namespace Andreys.Services
{
    public interface IProductsService
    {
        void Add(ProductAddInputModel productAddInputModel);

        IQueryable<Product> GetAll();

        Product GetById(int id);
    }
}
