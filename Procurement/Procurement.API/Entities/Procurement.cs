using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.API.Entities
{
    public class Procurement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("TotalPrice")]
        public double TotalPrice { get; set; }
        public string RequestDate { get; set; }
        public IEnumerable<Part> Parts { get; set; }
    }
}
