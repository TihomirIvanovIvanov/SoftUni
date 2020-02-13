using Andreys.Models;
using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAll();
    }
}
