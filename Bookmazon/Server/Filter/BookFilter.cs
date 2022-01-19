using Bookmazon.Shared.Filter;
using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Filter
{
    public class BookFilter : FilterGroup
    {
        public BookFilter()
        {
            //AddFilter(new SelectFilter<int> { PropertyName = nameof(Book.GenreID)});
            //AddFilter(new RangeFilter { PropertyName = nameof(Book.PriceSell) });
            //AddFilter(new SelectFilter<int> { PropertyName = nameof(Book.Authors) });
            //AddFilter(new SelectFilter<string> { PropertyName = nameof(Book.Language) });
            AddFilter(new LikeFilter { PropertyName = nameof(Book.Title) });
        }
    }
}
