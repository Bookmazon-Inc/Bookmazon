using Bookmazon.Shared.Models;
using System;


namespace Bookmazon.Shared.Dtos.Book
{
    public class BookCreateDto
    {
        // Properties
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public string? Notes { get; set; }
        public decimal NetPriceSell { get; set; }
        public decimal PricePurchase { get; set; }

        // Foreign Key
        public string LanguageCode { get; set; }
        public int GenreID { get; set; }
        public int PublisherID { get; set; }
        public int VATID { get; set; }

        public ICollection<int>? AuthorIds { get; set; }
    }
}
