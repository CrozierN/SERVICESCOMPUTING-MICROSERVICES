using MongoDB.Driver;
using Procurement.API.Entities;

namespace Procurement.API.Data
{
    public interface IProcurementContext
    {
        IMongoCollection<Entities.Procurement> Procurements { get; }
    }
}
