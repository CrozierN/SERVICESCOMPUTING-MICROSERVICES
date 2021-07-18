using MongoDB.Driver;
using Production.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Data
{
    public class ProductionContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Production> productionCollection)
        {
            bool existProduction = productionCollection.Find(p => true).Any();

            if (!existProduction)
            {
                productionCollection.InsertManyAsync(GetPreconfiguredProduction());
            }
        }

        private static IEnumerable<Entities.Production> GetPreconfiguredProduction()
        {
            return new List<Entities.Production>()
            {
                new Entities.Production()
                {
                    Id = "602d2149e773f2a3990b1234",
                    NumberOfOrders = 100,
                    MissingParts = new List<MissingPart>()
                    {
                        new MissingPart()
                        {
                            PartId = "A001",
                            Quantity = 10,
                        },
                        new MissingPart()
                        {
                            PartId = "A002",
                            Quantity = 2,
                        }
                    }
                }
            };
        }
    }
}
