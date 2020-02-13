using Andreys.Data;
using Andreys.Models;
using System.Collections.Generic;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = this.db.Products;
            return products;
        }
    }
}
