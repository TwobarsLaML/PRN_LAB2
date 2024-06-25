﻿using BusinessObjects;
using System.Collections.Generic;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        List<Product> GetProducts();
        Product GetProductById(int id);

    }
}