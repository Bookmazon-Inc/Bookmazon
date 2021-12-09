namespace Bookmazon.Server.Interfaces.Filter
{
    public interface IRangeFilter
    {
        public int? Start { get; init; }
        public int? End { get; set; }

        public bool InRange(int num);
    }
}
