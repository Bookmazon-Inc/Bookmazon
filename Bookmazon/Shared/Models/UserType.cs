using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmazon.Shared.Models
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; } 


        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }    


        [Required]
        [StringLength(50)]
        public string Description { get; set; } 

    }
}
