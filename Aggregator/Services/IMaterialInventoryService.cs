using System;
using Aggregator.Models;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public interface IMaterialInventoryService
    {
        public Task<Material> GetMaterial(string id);
    }
}
