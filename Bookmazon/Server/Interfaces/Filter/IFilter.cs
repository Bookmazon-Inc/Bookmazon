namespace Bookmazon.Server.Interfaces.Filter
{
    public interface IFilter<T> where T : class
    {
        public IQueryable<T> Apply(IQueryable<T> query);
    }
}
