using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Dtos.Cart
{
    public class CartItemDto
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PictureURL { get; set; }

        public decimal Price { get; set; }
        
        public int Amount { get; set; }
    }
}
