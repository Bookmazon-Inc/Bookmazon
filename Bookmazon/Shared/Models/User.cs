using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmazon.Shared.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }


        [Required]
        [StringLength(256)]
        public string UserName { get; set; }    


        [StringLength(100)]
        public string? LastName { get; set; }


        [StringLength(100)]
        public string? FirstName { get; set; }


        [StringLength(100)]
        public string? CompanyName { get; set; }


        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

        public string? Salt { get; set; }



        //Relation
        public virtual ICollection<CustomerOrder>? CustomerOrders { get; set;}
        public virtual ICollection<Roles>? Roles { get; set; }

    }
}
