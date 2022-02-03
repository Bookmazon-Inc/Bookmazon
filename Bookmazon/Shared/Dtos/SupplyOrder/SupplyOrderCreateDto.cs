using Bookmazon.Shared.Dtos.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Dtos.SupplyOrder

{
    public class SupplyOrderCreateDto
    {
        public int SupplyOrderID { get; set; }

        public DateTime SupplyOrderDate { get; set; }
        public int Discount { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // Foreign Key
        public int SupplierID { get; set; }
        public int SupplyOrderStateID { get; set; }
        public ICollection<SupplyOrderPositionCreateDto>? SupplyOrderPositions { get; set; }

    }
}
