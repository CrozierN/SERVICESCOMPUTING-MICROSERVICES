using System;
namespace Aggregator.Models
{
    public class Part
    {
        public string PartId { get; set; }
        public string PartName { get; set; }
        public string PartModel { get; set; }
        public double PartPrice { get; set; }
        public string Fit { get; set; }
        public double Quantity { get; set; }
        public Supplier Supplier { get; set; }
        public string Recommend { get; set; }
    }
}
