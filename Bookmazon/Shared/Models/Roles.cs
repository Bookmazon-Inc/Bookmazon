using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmazon.Shared.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; } 


        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        // n:m Relation
        public virtual ICollection<User> User { get; set; }


    }
}
