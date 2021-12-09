using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmazon.Shared.Models
{
    public class Storage
    {
        [Key]
        [StringLength(13)]
        public string ISBN { get; set; }   
        
        [Key]
        [ForeignKey("StorageLocation")]
        public int StorageLocationID { get; set; } 


        [Required]
        public int Amount { get; set; }


        //1:n Relation
        public StorageLocation StorageLocation { get; set; }    
    }
}
