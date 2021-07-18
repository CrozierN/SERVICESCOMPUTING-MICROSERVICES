using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.API.Entities
{
    public class Part
    {
        public string PartId { get; set; }
        public string PartName { get; set; }
        public double PartPrice { get; set; }
        public double Quantity { get; set; }
        public Supplier Supplier { get; set; }
    }
}
