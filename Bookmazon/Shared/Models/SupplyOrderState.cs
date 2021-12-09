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
        public int SupplayOrderStateID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public virtual ICollection<SupplyOrder> SupplyOrders { get; set; }
    }
}
