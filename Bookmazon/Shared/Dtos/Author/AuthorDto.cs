using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Dtos.Author
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Penname { get; set; }
        public string? Description { get; set; }
    }
}
