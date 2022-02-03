using Bookmazon.Shared.Dtos.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Dtos.SupplyOrder

{
    public class SupplyOrderPositionCreateDto
    {
        public int SupplyOrderID { get; set; }

        public int SupplyOrderPositionID { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }


        // Objects (1:n relationship)
        public int SupplyOrderPositionStateID { get; set; }

        public string ISBN { get; set; }

    }
}
