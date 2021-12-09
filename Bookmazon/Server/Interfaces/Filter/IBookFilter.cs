using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Interfaces.Filter
{
    public interface IBookFilter : IFilter<Book>
    {
        ISelectFilter<int> Genres { get; init; }
        ISelectFilter<int> Authors { get; init; }
        ISelectFilter<string> Languages { get; init; }
        IRangeFilter Price { get; init; }

    }
}
