using MongoDB.Driver;
using Procurement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.API.Data
{
    public class ProcurementContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Procurement> procurementCollection)
        {
            bool existProcure = procurementCollection.Find(p => true).Any();

            if (!existProcure)
            {
                procurementCollection.InsertManyAsync(GetPreconfiguredProcurement());
            }
        }

        private static IEnumerable<Entities.Procurement> GetPreconfiguredProcurement()
        {
            return new List<Entities.Procurement>()
            {
                new Entities.Procurement()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    TotalPrice = 180,
                    RequestDate = "15/05/2021",
                    Parts = new List<Part>()
                    {
                        new Part()
                        {
                            PartId = "A001",
                            PartName = "Windshield",
                            PartPrice = 100,
                            Quantity = 10,
                            Supplier = new Supplier()
                            {
                                SupplierName = "Toy Supplier",
                                SupplierAddress1 = "12 Test Street",
                                SupplierAddress2 = "",
                                SupplierPostalCode = "2021"
                            }
                        },
                        new Part()
                        {
                            PartId = "A002",
                            PartName = "Bonnet",
                            PartPrice = 80,
                            Quantity = 2,
                            Supplier = new Supplier()
                            {
                                SupplierName = "Toy Store Supplier",
                                SupplierAddress1 = "13 Test Strret",
                                SupplierAddress2 = "",
                                SupplierPostalCode = "2022"
                            }
                        }
                    }
                }
            };
        }
    }
}
