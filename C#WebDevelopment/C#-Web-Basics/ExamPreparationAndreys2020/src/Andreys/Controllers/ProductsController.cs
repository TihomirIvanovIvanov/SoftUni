using Andreys.Models;
using Andreys.Services;
using Andreys.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;
using System;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name should be between 4 and 20 characters!");
            }

            if (input.Description.Length > 10)
            {
                return this.Error("Description should be max 10 characters!");
            }

            if (input.Price <= 0)
            {
                return this.Error("Price must be a positive number!");
            }

            if (string.IsNullOrWhiteSpace(input.Category))
            {
                return this.Error("Category cannot be empty!");
            }

            if (string.IsNullOrWhiteSpace(input.Gender))
            {
                return this.Error("Category cannot be empty!");
            }

            this.productsService
                .Create(input.Name, input.Description, input.ImageUrl, input.Category, input.Gender, input.Price);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.productsService.Details(id);

            var producsDetails = new DetailsViewModel
            {
                Name = product.Name,
                Gender = product.Gender.ToString(),
                Category = product.Category.ToString(),
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                Price = product.Price,
                Id = product.Id,
            };

            return this.View(producsDetails);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.Delete(id);

            return this.Redirect("/");
        }
    }
}
