using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class CustomerOrderPosition
    {
        [Key]
        public int CustomerOrderPositionID { get; set; }


        [Key]
        [ForeignKey("CustomerOrder")]
        public int CustomerOrderID { get; set; }


        [ForeignKey("CustomerOrderPositionState")]
        public int CustomerOrderPositionStateID { get; set; }


        [Required]
        public int Amount { get; set; }

        [ForeignKey("Book)")]
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }


        public int Discount { get; set; }



        //Relations
        public virtual CustomerOrderPositionState? CustomerOrderPositionState { get; set; }
        public virtual CustomerOrder CustomerOrder { get; set; }

        public virtual Book Books { get; set; }
    }
}
