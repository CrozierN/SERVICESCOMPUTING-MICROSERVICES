using System;
using System.Net.Http;
using System.Threading.Tasks;
using Aggregator.Extensions;
using Aggregator.Models;

namespace Aggregator.Services
{
    public class MaterialInventoryService : IMaterialInventoryService
    {
        private readonly HttpClient _client;

        public MaterialInventoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Material> GetMaterial(string id)
        {
            var response = await _client.GetAsync($"/api/v1/material/{id}");
            return await response.ReadContentAs<Material>();
        }
    }
}
