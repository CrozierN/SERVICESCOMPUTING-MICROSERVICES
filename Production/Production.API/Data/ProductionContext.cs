using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Production.API.Entities;

namespace Production.API.Data
{
    public class ProductionContext : IProductionContext
    {
        public ProductionContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Productions = database.GetCollection<Entities.Production>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ProductionContextSeed.SeedData(Productions);
        }
        public IMongoCollection<Entities.Production> Productions { get; }
    }
}
