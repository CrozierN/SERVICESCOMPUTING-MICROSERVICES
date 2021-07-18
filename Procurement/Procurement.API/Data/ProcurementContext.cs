using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Procurement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.API.Data
{
    public class ProcurementContext : IProcurementContext
    {
        public ProcurementContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Procurements = database.GetCollection<Entities.Procurement>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ProcurementContextSeed.SeedData(Procurements);
        }
        public IMongoCollection<Entities.Procurement> Procurements { get; }

    
    }
}
