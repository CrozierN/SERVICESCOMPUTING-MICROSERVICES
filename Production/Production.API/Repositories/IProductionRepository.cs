using Production.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Repositories
{
    public interface IProductionRepository
    {
        Task<IEnumerable<Entities.Production>> GetProductions();
        Task<Entities.Production> GetProduction(string id);
        Task CreateProduction(Entities.Production production);
        Task<bool> UpdateProduction(Entities.Production production);
        Task<bool> DeleteProduction(string id);
    }
}
