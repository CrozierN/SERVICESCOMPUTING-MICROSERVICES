using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Entities
{
    public class Production
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int NumberOfOrders { get; set; }
        public IEnumerable<MissingPart> MissingParts{ get; set; }
    }
}
