using System;
using System.Linq;
using MaterialInventory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MaterialInventory.Models
{
    public class SeedMaterial
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MaterialContext(
                serviceProvider.GetRequiredService<DbContextOptions<MaterialContext>>()))
            {
                if (context.Material.Any())
                {
                    return;
                }

                context.Material.AddRange(
                    new Material()
                    {
                        Id = "HW1",
                        part_name = "Body",
                        part_model = "M3",
                        quantity = 1,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW2",
                        part_name = "Interior Sits",
                        part_model = "M3",
                        quantity = 1,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW3",
                        part_name = "Dashboard",
                        part_model = "M3",
                        quantity = 1,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW4",
                        part_name = "Steering Wheel",
                        part_model = "M3",
                        quantity = 1,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW5",
                        part_name = "Font Window",
                        part_model = "M3",
                        quantity = 1,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW6",
                        part_name = "Rear Window",
                        part_model = "M3",
                        quantity = 1,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW7",
                        part_name = "Front Doors",
                        part_model = "M3",
                        quantity = 2,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW8",
                        part_name = "Back Doors",
                        part_model = "M3",
                        quantity = 2,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW9",
                        part_name = "Front Wheels",
                        part_model = "M3",
                        quantity = 2,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW10",
                        part_name = "Back Wheels",
                        part_model = "M3",
                        quantity = 2,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW11",
                        part_name = "Front Lights",
                        part_model = "M3",
                        quantity = 2,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW12",
                        part_name = "Backlights",
                        part_model = "M3",
                        quantity = 2,
                        fit = "BMW"
                    },
                    new Material()
                    {
                        Id = "HW13",
                        part_name = "Car Battery",
                        part_model = "M3",
                        quantity = 1,
                        fit = "BMW"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
