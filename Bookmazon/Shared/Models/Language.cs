using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public class Language
    {
        [Key][StringLength(2)]
        public string LanguageCode { get; set; }
        [Required][StringLength(50)]
        public string Fullname { get; set; }
    
        // Relationship
        public virtual ICollection<Product> Products { get; set; }
    }
}
