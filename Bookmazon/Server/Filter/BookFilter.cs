using Bookmazon.Shared.Filter;
using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Filter
{
    public class BookFilter : FilterGroup<Book>
    {
        public BookFilter()
        {
            AddFilter(new SelectFilter<Book, int> { PropertyName = nameof(Book.GenreID), Name = "genre"});
            AddFilter(new RangeFilter<Book> { PropertyName = nameof(Book.NetPriceSell), Name = "price" });
            //AddFilter(new SelectFilter<int> { PropertyName = nameof(Book.Authors) });
            //AddFilter(new SelectFilter<string> { PropertyName = nameof(Book.) });
            AddFilter(new LikeFilter<Book> { PropertyName = nameof(Book.Title), Name = "q" });
        }
    }
}
