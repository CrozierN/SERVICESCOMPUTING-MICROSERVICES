using MongoDB.Driver;
using Production.API.Entities;

namespace Production.API.Data
{
    public interface IProductionContext
    {
        IMongoCollection<Entities.Production> Productions { get; }
    }
}
