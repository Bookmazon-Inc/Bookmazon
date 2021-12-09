using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }


        [Required][StringLength(50)]
        public string PublisherName { get; set; }


    
        // Relationship
        public virtual ICollection<Book> Books { get; set; }
    }
}
