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
        

        [Key]
        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }


        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }


        [Required]
        [StringLength(40)]
        public string ProductTitle { get; set; }


        [Required]
        public int Amount { get; set; }


        [Required]
        [Column(TypeName ="decimal (18,4)")]
        public decimal NetPrice { get; set; }


        [Required]
        [Column(TypeName = "decimal (18,4)")]
        public decimal GrossPrice { get; set; }


        [Required]
        [Range(0,100)]
        public int Discount { get; set; }

        // 1:n Relation
        public Invoice Invoice { get; set; }
    }
}
