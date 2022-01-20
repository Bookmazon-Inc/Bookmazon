using Bookmazon.Shared.Dtos.Genre;
using Bookmazon.Shared.Dtos.Language;
using Bookmazon.Shared.Dtos.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Dtos.Book
{
    public class BookDto
    {

        public string ISBN { get; set; }


        public string Title { get; set; }


        public string Description { get; set; }


        public string PictureURL { get; set; }

        public decimal Price { get; set; }


        // Objects (1:n relationship)
        public LanguageDto Language { get; set; }

        public GenreDto Genre { get; set; }

        public PublisherDto Publisher { get; set; }

    }
}
