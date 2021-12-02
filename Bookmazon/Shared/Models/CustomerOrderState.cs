using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class CustomerOrderState
    {
        public int CustomerOrderStateId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(100)]
        public string? Notes { get; set; }

        public ICollection<CustomerOrder>? CustomerOrders { get; set; }
    }
}
