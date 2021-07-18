using System;
using System.ComponentModel.DataAnnotations;

namespace MaterialInventory.DTOs
{
    public class UpdateMaterialDTO
    {

        [Required]
        public int quantity { get; set; }
    }
}
