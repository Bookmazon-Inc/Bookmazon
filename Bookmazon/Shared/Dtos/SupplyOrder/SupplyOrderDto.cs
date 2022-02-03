using Bookmazon.Shared.Dtos.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Dtos.SupplyOrder

{
    public class SupplyOrderDto
    {
        public int SupplyOrderID { get; set; }

        public DateTime SupplyOrderDate { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // Objects (1:n relationship)
        public SupplierDto Supplier { get; set; }
        public SupplyOrderStateDto SupplyOrderState { get; set; }
    }
}
