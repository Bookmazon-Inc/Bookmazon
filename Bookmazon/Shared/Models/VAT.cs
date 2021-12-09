using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class VAT
    {
        [Key]
        public int VATID { get; set; }
        public int VATPercentage { get; set; }
    
        // Relationship
        public virtual ICollection<Book> Books { get; set; }
    }
}
