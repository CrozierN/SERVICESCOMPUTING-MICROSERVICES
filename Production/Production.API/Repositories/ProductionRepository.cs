using MongoDB.Driver;
using Production.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly IProductionContext _context;

        public ProductionRepository(IProductionContext context)
        {
            _context = context;
        }

        public async Task CreateProduction(Entities.Production production)
        {
            await _context.Productions.InsertOneAsync(production);
        }

        public async Task<bool> DeleteProduction(string id)
        {
            FilterDefinition<Entities.Production> filter = Builders<Entities.Production>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Productions
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Entities.Production> GetProduction(string id)
        {
            return await _context
                    .Productions
                    .Find(p => p.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Production>> GetProductions()
        {
            return await _context
                    .Productions
                    .Find(p => true)
                    .ToListAsync();
        }

        public async Task<bool> UpdateProduction(Entities.Production production)
        {
            var updateResult = await _context
                                .Productions
                                .ReplaceOneAsync(filter: g => g.Id == production.Id, replacement: production);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
