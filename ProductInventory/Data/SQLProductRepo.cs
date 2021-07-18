using System;
using System.Collections.Generic;
using System.Linq;
using InventoryStorage.Models;

namespace InventoryStorage.Data
{
    public class SQLProductRepo : IManageProductRepo
    {
        private readonly ProductContext _context;

        public SQLProductRepo(ProductContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product productItem)
        {
            if(productItem == null)
            {
                throw new ArgumentNullException(nameof(productItem));
            }

            _context.Product.Add(productItem);
        }

        public void DeleteProduct(Product productItem)
        {
            if(productItem == null)
            {
                throw new ArgumentNullException(nameof(productItem));
            }

            _context.Product.Remove(productItem);
        }

        public Product GetProductById(string productId)
        {
            return _context.Product.FirstOrDefault(p => p.productId == productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Product.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProduct(Product productItem)
        {
            //throw new NotImplementedException();
        }
    }
}
