using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmazon.Shared.Models
{
    public class StorageLocation
    {
        [Key]
        public int StorageLocationID { get; set; }  


        [Required]
        [StringLength(50)]
        public string LocationName { get; set; }    

    }
}
