using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class SupplyOrderPositionState
    {
        [Key]
        public int SupplayOrderPositionStateID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public virtual ICollection<SupplyOrderPosition> SupplyOrderPositions { get; set; }
    }
}
