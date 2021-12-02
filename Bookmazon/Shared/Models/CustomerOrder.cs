using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class CustomerOrder
    {
        public int CustomerOrderId { get; set; }

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

        public int UserId { get; set; }


        public int CustomerOrderStateId { get; set; }

        public virtual CustomerOrderState CustomerOrderState { get; set; }

        public virtual ICollection<CustomerOrderPosition> CustomerOrderPositions { get; set; }
    }
}
