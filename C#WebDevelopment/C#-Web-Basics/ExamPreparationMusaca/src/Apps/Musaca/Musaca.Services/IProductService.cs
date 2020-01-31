﻿using Musaca.Models;
using System.Collections.Generic;

namespace Musaca.Services
{
    public interface IProductService
    {
        Product CreateProduct(Product product);

        Product GetByName(string name);

        List<Product> GetAll();
    }
}
