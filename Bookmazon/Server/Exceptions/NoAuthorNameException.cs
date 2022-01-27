namespace Bookmazon.Server.Exceptions
{
    public class NoAuthorNameException : Exception
    {
        /// <summary>
        /// If an Author has neither a first and last or penname, this exception is thrown
        /// </summary>
        /// <param name="EntityName"></param>
        public NoAuthorNameException(string EntityName) : base(EntityName)
        {
        }
    }
}
