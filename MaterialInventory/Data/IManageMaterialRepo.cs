using System;
using System.Collections.Generic;
using MaterialInventory.Models;

namespace MaterialInventory.Data
{
    public interface IManageMaterialRepo
    {

        bool SaveChanges();

        IEnumerable<Material> Materials();
        Material GetMaterial(string Id);
        void CreateNewMaterial(Material materialItem);
        void UpdateMaterial(Material materialItem);
        void DeleteMaterial(Material materialItem);

    }
}
