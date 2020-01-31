using Musaca.Data;
using Musaca.Models;
using System.Collections.Generic;
using System.Linq;

namespace Musaca.Services
{
    public class ProductService : IProductService
    {
        private readonly MusacaDbContext context;

        public ProductService(MusacaDbContext context)
        {
            this.context = context;
        }

        public Product CreateProduct(Product product)
        {
            this.context.Add(product);
            this.context.SaveChanges();

            return product;
        }

        public List<Product> GetAll()
        {
            var products = this.context.Products.ToList();
            return products;
        }

        public Product GetByName(string name)
        {
            var products = this.context.Products.SingleOrDefault(product => product.Name == name);
            return products;
        }
    }
}
