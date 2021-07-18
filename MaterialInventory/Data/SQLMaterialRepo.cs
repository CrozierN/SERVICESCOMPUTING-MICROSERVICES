using System;
using System.Collections.Generic;
using System.Linq;
using MaterialInventory.Models;

namespace MaterialInventory.Data
{
    public class SQLMaterialRepo : IManageMaterialRepo
    {
        private readonly MaterialContext _context;

        public SQLMaterialRepo(MaterialContext context)
        {
            _context = context;
        }

        public void CreateNewMaterial(Material materialItem)
        {
            if (materialItem == null)
            {
                throw new ArgumentNullException(nameof(materialItem));
            }

            _context.Material.Add(materialItem);
        }

        public void DeleteMaterial(Material materialItem)
        {
            if (materialItem == null)
            {
                throw new ArgumentNullException(nameof(materialItem));
            }

            _context.Material.Remove(materialItem);
        }

        public Material GetMaterial(string id)
        {
            return _context.Material.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Material> Materials()
        {
            return _context.Material.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMaterial(Material materialItem)
        {
            //throw new NotImplementedException();
        }
    }
}
