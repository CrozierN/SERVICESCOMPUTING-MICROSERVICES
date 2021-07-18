using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Entities
{
    public class MissingPart
    {
        public string PartId { get; set; }
        public int Quantity { get; set; }
    }
}
