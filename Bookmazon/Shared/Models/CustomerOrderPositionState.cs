using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class CustomerOrderPositionState
    {
        public int CustomerOrderPositionStateId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(100)]
        public string? Notes { get; set; }

        public ICollection<CustomerOrderPosition>?  CustomerOrderPositions { get; set; }
    }
}
