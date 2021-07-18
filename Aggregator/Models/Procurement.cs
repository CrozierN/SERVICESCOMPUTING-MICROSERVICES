using System.Collections.Generic;

namespace Aggregator.Models
{
    public class Procurement
    {
        public string Id { get; set; }
        public double TotalPrice { get; set; }
        public string RequestDate { get; set; }
        public IEnumerable<Part> Parts { get; set; }
    }
}
