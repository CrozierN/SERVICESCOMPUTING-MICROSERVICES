using System;
using System.Threading.Tasks;
using Aggregator.Models;

namespace Aggregator.Services
{
    public interface IProcurementService
    {
        public Task<Procurement> GetProcurement(string id);
    }
}
