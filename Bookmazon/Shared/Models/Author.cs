using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [StringLength(100)]
        public string? Lastname { get; set; }
        [StringLength(100)]
        public string? Firstname { get; set; }
        [StringLength(100)]
        public string? Penname { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
    
        // Relationship
        public virtual ICollection<Book> Books { get; set; }
    }
}
