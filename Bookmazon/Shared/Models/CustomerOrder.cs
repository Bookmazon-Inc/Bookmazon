using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class CustomerOrder
    {
        [Key]
        public int CustomerOrderID { get; set; }


        public DateTime OrderDate { get; set; }


        [Range(0, 100)]
        public int Discount { get; set; }


        [Required]
        [StringLength(150)]
        public string  Address { get; set; }


        [Required]
        [StringLength(15)]
        public string ZIP { get; set; }


        [Required]
        [StringLength(100)]
        public string City { get; set; }


        [Required]
        [StringLength(100)]
        public string Country { get; set; }


        [ForeignKey("User")]
        public int UserID { get; set; }


        [ForeignKey("CustomerOrderState")]
        public int CustomerOrderStateID { get; set; }



        //Relation
        public virtual CustomerOrderState CustomerOrderState { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CustomerOrderPosition> CustomerOrderPositions { get; set; }
    }
}
