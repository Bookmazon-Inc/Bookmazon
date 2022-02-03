using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class SupplyOrder
    {
        [Key]
        public int SupplyOrderID { get; set; }


        public DateTime SupplyOrderDate { get; set; }



        [StringLength(500)]
        public string? Notes { get; set; }


        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }


        [ForeignKey("SupplyOrderState")]
        public int SupplyOrderStateID { get; set; }

        // Relationships
        public virtual Supplier Supplier { get; set; }
        public virtual SupplyOrderState SupplyOrderState { get; set; }
        public virtual ICollection<SupplyOrderPosition> SupplyOrderPositions { get; set; }
    }
}
