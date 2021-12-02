using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        [Required]
        public DateTime Startdate { get; set; }
        [Required]
        public DateTime Enddate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? DiscountValue { get; set; }
        [Range(0,100)]
        public int? DiscountPercentage { get; set; }
        [Required][StringLength(50)]
        public string DiscountName { get; set; }
    
        // Relationship
        public virtual ICollection<Product> Products { get; set; }
    }
}
