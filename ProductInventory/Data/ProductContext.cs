using System;
using InventoryStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryStorage.Data
{
    [Keyless]
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> opt) : base(opt){ }

        public DbSet<Product> Product { get; set; }
    }
}
