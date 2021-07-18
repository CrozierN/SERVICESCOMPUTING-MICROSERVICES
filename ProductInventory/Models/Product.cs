using System;
namespace InventoryStorage.Models
{
    public class Product
    {
        public string productId { get; set; }
        public string fit { get; set; }
        public string model { get; set; }
        public ProductColor color { get; set; }
        public int quantity { get; set; }
        public int orderNumber { get; set; }
    }
}
