using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class SupplyOrder
    {
        public int SupplyOrderId { get; set; }

        public DateTime SupplyOrderDate { get; set; }

        public int Discount { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public int SupplierId { get; set; }

        public int SupplyOrderStateId { get; set; }

        public virtual SupplyOrderState SupplyOrderState { get; set; }
        public virtual ICollection<SupplyOrderPosition> SupplyOrderPositions { get; set; }
    }
}
