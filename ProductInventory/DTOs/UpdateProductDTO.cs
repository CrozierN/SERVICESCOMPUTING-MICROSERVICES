using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryStorage.DTOs
{
    public class UpdateProductDTO
    {
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
