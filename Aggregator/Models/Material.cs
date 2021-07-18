﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MaterialInventory.Models
{
    public class Material
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string part_name { get; set; }

        [Required]
        [MaxLength(255)]
        public string part_model { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        [MaxLength(255)]
        public string fit { get; set; }
    }
}
