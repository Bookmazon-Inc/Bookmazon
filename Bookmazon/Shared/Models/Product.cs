using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class Product
    {
        [Key][StringLength(13)]
        public string ISBN { get; set; }
        [Required][StringLength(120)]
        public string Title { get; set; }
        [Required][StringLength(800)]
        public string Description { get; set; }
        [Required][StringLength(2000)]
        public string PictureURL { get; set; }
        [Required][StringLength(400)]
        public string? Notes { get; set; }

        // Relationship Fields
        [StringLength(2)]
        public string LanguageCode { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }
        public int VATId { get; set; }
    
        // Objects (1:n relationship)
        public Language Language { get; set; }
        public Genre Genre { get; set; }
        public Publisher Publisher { get; set; }
        public VAT VAT { get; set; }

        // Lists (n:m relationship)
        public virtual ICollection<Supplier> Suppliers { get; set; } 
        public virtual ICollection<Discount> Discounts  { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
