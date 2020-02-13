using Andreys.Models;
using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAll();

        void Create(string name, string description, string imageUrl, string category, string gender, decimal price);

        Product Details(string id);

        void Delete(string id);
    }
}
