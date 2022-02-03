using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Dtos.SupplyOrder

{
    public class SupplyOrderPositionStateDto
    {
        public int SupplyOrderPositionStateID { get; set; }

        public string Title { get; set; }

    }
}
