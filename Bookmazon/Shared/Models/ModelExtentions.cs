using Bookmazon.Shared.Dtos.Book;
using Bookmazon.Shared.Dtos.Genre;
using Bookmazon.Shared.Dtos.Language;
using Bookmazon.Shared.Dtos.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Models
{
    public static class ModelExtentions
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto { ISBN = book.ISBN, Title = book.Title, Description = book.Description, Genre = book.Genre?.ToGenreDto(), Language = book.Language?.ToLanguageDto(), PictureURL = book.PictureURL, Price = 0, Publisher = book.Publisher?.ToPublisherDto() }; 
        }

        public static GenreDto ToGenreDto(this Genre genre)
        {
            return new GenreDto { GenreId = genre.GenreId, Title = genre.Title };
        }

        public static LanguageDto ToLanguageDto(this Language language)
        {
            return new LanguageDto { FullName = language.FullName, LanguageCode = language.LanguageCode };
        }

        public static PublisherDto ToPublisherDto(this Publisher publisher)
        {
            return new PublisherDto { PublisherId = publisher.PublisherId, PublisherName = publisher.PublisherName };
        }
    }
}
