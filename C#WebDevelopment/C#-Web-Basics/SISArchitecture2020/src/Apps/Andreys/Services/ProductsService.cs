using Andreys.Data;
using Andreys.Models;
using Andreys.ViewModels.Products;
using System;
using System.Linq;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(ProductAddInputModel productAddInputModel)
        {
            var category = Enum.Parse<Category>(productAddInputModel.Category);
            var gender = Enum.Parse<Gender>(productAddInputModel.Gender);

            var product = new Product
            {
                Name = productAddInputModel.Name,
                Description = productAddInputModel.Description,
                ImageUrl = productAddInputModel.ImageUrl,
                Price = productAddInputModel.Price,
                Category = category,
                Gender = gender,
            };

            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();

            return product.Id;
        }

        public IQueryable<Product> GetAll()
        {
            var allProducts = this.dbContext.Products
                .Select(product => new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    ImageUrl = product.ImageUrl,
                    Category = product.Category,
                    Price = product.Price,

                }).AsQueryable();

            return allProducts;
        }
    }
}
