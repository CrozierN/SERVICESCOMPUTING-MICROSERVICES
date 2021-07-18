using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Aggregator.Extensions;
using Aggregator.Models;

namespace Aggregator.Services
{
    public class ProcurementService : IProcurementService
    {
        private readonly HttpClient _client;

        public ProcurementService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Procurement> GetProcurement(string id)
        {
            //var response = await _client.GetAsync($"/api/v1/procurement/{id}");
            //var response = await _client.GetAsync()

            ServicePointManager.ServerCertificateValidationCallback +=
            (sender, certificate, chain, errors) => {
                return true;
            };

            var response = await _client.GetAsync($"/api/v1/procurement/{id}");

            return await response.ReadContentAs<Procurement>();
        }
    }
}
