using System;
using MaterialInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace MaterialInventory.Data
{
    [Keyless]
    public class MaterialContext : DbContext
    {

        public MaterialContext(DbContextOptions<MaterialContext> opt) : base(opt) { }

        public DbSet<Material> Material { set; get; }
    }
}
