using System;
using System.Linq;
using InventoryStorage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryStorage.Models
{
    public static class SeedProduct
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProductContext>>()))
            {
                if (context.Product.Any())
                {
                    return;
                }


                context.Product.AddRange(
                    new Product()
                    {
                        productId = "PR1",
                        fit = "BMW",
                        model = "M3",
                        color = ProductColor.White,
                        quantity = 0,
                        orderNumber = 0
                    },
                    new Product()
                    {
                        productId = "PR2",
                        fit = "Mercedes-Benz",
                        model = "A-45",
                        color = ProductColor.Red,
                        quantity = 0,
                        orderNumber = 0
                    }
                );
            }
        }
    }
}
