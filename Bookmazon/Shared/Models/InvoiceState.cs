using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmazon.Shared.Models
{
    public class InvoiceState
    {
        [Key]
        public int InvoiceStateID { get; set; }


        [Required]
        [StringLength(50)]
        public string Title { get; set; }


        [StringLength(50)]
        public string? Notes { get; set; }

    }
}
