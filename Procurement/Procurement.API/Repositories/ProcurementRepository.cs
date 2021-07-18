
using MongoDB.Driver;
using Procurement.API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procurement.API.Repositories
{
    public class ProcurementRepository : IProcurementRepository
    {
        private readonly IProcurementContext _context;

        public ProcurementRepository(IProcurementContext context)
        {
            _context = context;
        }

        public async Task CreateProcurement(Entities.Procurement procurement)
        {
            await _context.Procurements.InsertOneAsync(procurement);
        }

        public async Task<bool> DeleteProcurement(string id)
        {
            FilterDefinition<Entities.Procurement> filter = Builders<Entities.Procurement>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Procurements
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Entities.Procurement>> GetProcurementByRequestDate(string requestDate)
        {
            FilterDefinition<Entities.Procurement> filter = Builders<Entities.Procurement>.Filter.ElemMatch(p => p.RequestDate, requestDate);
            return await _context
                    .Procurements
                    .Find(filter)
                    .ToListAsync();
        }

        public async Task<Entities.Procurement> GetProcurement(string id)
        {
            return await _context
                    .Procurements
                    .Find(p => p.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Procurement>> GetProcurements()
        {
            return await _context
                    .Procurements
                    .Find(p => true)
                    .ToListAsync();
        }

 
        public async Task<bool> UpdateProcurement(Entities.Procurement procurement)
        {
            var updateResult = await _context
                                .Procurements
                                .ReplaceOneAsync(filter: g => g.Id == procurement.Id, replacement: procurement);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
