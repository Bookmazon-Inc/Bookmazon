using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Dtos.Supplier

{
    public class BookSupplierDto
    {
        public int SupplierID { get; set; }
        public string ISBN { get; set; }

    }
}
