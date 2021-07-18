using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryStorage.DTOs
{
    public class ReadProductDTO
    {
        [Key]
        public string productId { get; set; }
        [Required]
        [MaxLength(255)]
        public string fit { get; set; }
        [Required]
        [MaxLength(255)]
        public string model { get; set; }
        [Required]
        [MaxLength(255)]
        public string color { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        [MaxLength(255)]
        public string orderNumber { get; set; }
    }
}
