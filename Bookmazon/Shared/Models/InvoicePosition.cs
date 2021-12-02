using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmazon.Shared.Models
{
    public class InvoicePosition
    {
        [Key]
        public int InvoicePositionID { get; set; }
        //fluent API 2.Key
        public int InvoiceID { get; set; }

        [Required]
        [StringLength(12)]
        public string ISBN { get; set; }


        [Required]
        [StringLength()]
        public string ProductTitle { get; set; }
        public int Amount { get; set; }
        public decimal NetPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public int Discount { get; set; }
    }
}
