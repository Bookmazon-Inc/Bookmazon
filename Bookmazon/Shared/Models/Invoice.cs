using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmazon.Shared.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }  


        [Required]
        public DateTime OrderDate { get; set; }


        [Required]
        public DateTime InvoiceDate { get; set; }


        [Required]
        public int UserID { get; set; }


        [StringLength(100)]
        public string? FirstName { get; set; }


        [StringLength(100)]
        public string? LastName { get; set; }


        [StringLength(100)]
        public string? CompanyName { get; set; }


        [Required]
        [StringLength(150)]
        public string Address { get; set; }


        [Required]
        [StringLength(15)]
        public string ZIP { get; set; }


        [Required]
        [StringLength(100)]
        public string City { get; set; }


        [Required]
        [StringLength(100)]
        public string Country { get; set; }


        [ForeignKey("InvoiceState")]
        public int InvoiceStateID { get; set; }
        

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal NetPrice { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal GrossPrice { get; set; }


        [Required]
        [Range(0,100)]
        public int Discount { get; set; }


        [Required]
        public int VATPercentage { get; set; }


        [StringLength(500)]
        public string? Notes { get; set; }


        // 1:n relations 
        public InvoiceState InvoiceState { get; set; }
    }
}
