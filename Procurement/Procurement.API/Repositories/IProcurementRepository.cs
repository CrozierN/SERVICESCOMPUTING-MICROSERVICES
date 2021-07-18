using Procurement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.API.Repositories
{
    public interface IProcurementRepository
    {
        Task<IEnumerable<Entities.Procurement>> GetProcurements();
        Task<Entities.Procurement> GetProcurement(string id);
        Task<IEnumerable<Entities.Procurement>> GetProcurementByRequestDate(string requestDate);
        Task CreateProcurement(Entities.Procurement procurement);
        Task<bool> UpdateProcurement(Entities.Procurement procurement);
        Task<bool> DeleteProcurement(string id);
    }
}
