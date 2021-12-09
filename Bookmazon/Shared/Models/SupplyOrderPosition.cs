using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class SupplyOrderPosition
    {
        [Key]
        [ForeignKey("SupplyOrder")]
        public int SuppllyOrderID { get; set; }

        [Key]
        public int SupplayOrderPositionID { get; set; }

        [Required()]
        public int Amount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Discount { get; set; }

        [ForeignKey("SupplyOrderPositionState")]
        public int SupplyOrderPositionStateID { get; set; }



        public virtual SupplyOrderPositionState SupplyOrderPositionState { get; set; }
        public virtual SupplyOrder SupplyOrder { get; set; }

        public virtual Book Books { get; set; }
    }
}
