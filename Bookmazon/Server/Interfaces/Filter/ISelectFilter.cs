namespace Bookmazon.Server.Interfaces.Filter
{
    public interface ISelectFilter<T>
    {
        ICollection<T> FilterList { get; init; }

        public bool InList(T value);
    }
}
