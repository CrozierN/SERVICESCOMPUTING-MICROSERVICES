using System;
using System.Collections.Generic;
using InventoryStorage.Models;

namespace InventoryStorage.Data
{
    public interface IManageProductRepo
    {

        bool SaveChanges();

        IEnumerable<Product> GetProducts();
        Product GetProductById(string productId);
        void CreateProduct(Product productItem);
        void UpdateProduct(Product productItem);
        void DeleteProduct(Product productItem);
    }
}
