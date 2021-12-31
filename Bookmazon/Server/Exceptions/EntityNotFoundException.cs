namespace Bookmazon.Server.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// If an entity is not found while calling an "ConnectXtoY"-Method, this exception is thrown
        /// </summary>
        /// <param name="EntityName">The name of the Entity that has not been found</param>
        public EntityNotFoundException(string EntityName) : base(EntityName)
        {
        }
    }
}
