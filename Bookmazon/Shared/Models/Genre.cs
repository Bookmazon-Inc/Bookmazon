using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required][StringLength(50)]
        public string Title { get; set; }
        [StringLength(400)]
        public string? Notes { get; set; }
    
        // Relationship
        public virtual ICollection<Product> Products { get; set; }  
    }
}
