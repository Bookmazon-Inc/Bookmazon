namespace  Bookmazon.Shared.Filter
{
    public interface IFilter
    {
        public string PropertyName { get;  init; }
        public string ToQueryString();
        public void FromQueryString(string queryString);
        public IQueryable<T> ApplyFilter<T>(IQueryable<T> query);
    }
}