using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.API.Entities
{
    public class Supplier
    {
        public string SupplierName { get; set; }
        public string SupplierAddress1 { get; set; }
        public string SupplierAddress2 { get; set; }
        public string SupplierPostalCode { get; set; }
    }
}
