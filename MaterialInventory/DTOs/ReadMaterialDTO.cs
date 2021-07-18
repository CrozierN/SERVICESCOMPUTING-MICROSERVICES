using System;
namespace MaterialInventory.DTOs
{
    public class ReadMaterialDTO
    {
        public string Id { get; set; }

        public string part_name { get; set; }

        public string part_model { get; set; }

        public int quantity { get; set; }

        public string fit { get; set; }
    }
}
