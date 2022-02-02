using Bookmazon.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Dtos.SupplyOrder
{
    public class SupplyOrderDto
    {
        public int SupplyOrderID { get; set; }
        public DateTime SupplyOrderDate { get; set; }
        public int Discount { get; set; }
        public string? Notes { get; set; }
        public Supplier Supplier { get; set; }
        public SupplyOrderState SupplyOrderState { get; set; }
        public virtual ICollection<SupplyOrderPosition> SupplyOrderPositions { get; set; }
    }
}
