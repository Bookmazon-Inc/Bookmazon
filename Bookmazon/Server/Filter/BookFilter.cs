using Bookmazon.Shared.Filter;
using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Filter
{
    public class BookFilter : FilterGroup<Book>
    {
        public BookFilter()
        {
            //AddFilter(new SelectFilter<int> { PropertyName = nameof(Book.GenreID)});
            AddFilter(new RangeFilter<Book> { PropertyName = nameof(Book.NetPriceSell), Name = "price" });
            //AddFilter(new SelectFilter<int> { PropertyName = nameof(Book.Authors) });
            //AddFilter(new SelectFilter<string> { PropertyName = nameof(Book.Language) });
            AddFilter(new LikeFilter<Book> { PropertyName = nameof(Book.Title), Name = "q" });
        }
    }
}
