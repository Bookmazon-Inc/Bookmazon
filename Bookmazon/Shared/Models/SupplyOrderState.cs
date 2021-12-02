using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class SupplyOrderState
    {
        [Key]
        public int SupplayOrderStateId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public ICollection<SupplyOrder> SupplyOrders { get; set; }
    }
}
