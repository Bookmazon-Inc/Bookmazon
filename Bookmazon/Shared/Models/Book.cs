using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class Book
    {
        [Key][StringLength(13)]
        public string ISBN { get; set; }


        [Required][StringLength(120)]
        public string Title { get; set; }


        [Required][StringLength(800)]
        public string Description { get; set; }


        [Required][StringLength(2000)]
        public string PictureURL { get; set; }


        [StringLength(400)]
        public string? Notes { get; set; }


        [Required][Column(TypeName = "decimal(18, 4)")]
        public decimal NetPriceSell { get; set; }


        [Required][Column(TypeName = "decimal(18, 4)")]
        public decimal PricePurchase { get; set; }

        [NotMapped]
        public decimal PriceSell => ((VAT.VATPercentage / 100) * NetPriceSell) + NetPriceSell; 
        



        // Relationship Fields
        [ForeignKey("Language")]
        [StringLength(2)]
        public string LanguageCode { get; set; }


        [ForeignKey("Genre")]
        public int GenreID { get; set; }


        [ForeignKey("Publisher")]
        public int PublisherID { get; set; }


        [ForeignKey("VAT")]
        public int VATID { get; set; }

    
        // Objects (1:n relationship)
        public Language Language { get; set; }

        public Genre Genre { get; set; }

        public Publisher Publisher { get; set; }

        public VAT VAT { get; set; }


        public virtual ICollection<CustomerOrderPosition> CustomerOrderPositions { get; set;}
        public virtual ICollection<SupplyOrderPosition> SupplyOrderPositions { get; set;}
        public virtual ICollection<Storage> Storage { get; set; }

        // Lists (n:m relationship)
        public virtual ICollection<Supplier> Suppliers { get; set; } 
        public virtual ICollection<Discount> Discounts  { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
