using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces.Repos;
using Bookmazon.Server.Exceptions;
using Bookmazon.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmazon.Server.Repos
{
    public class SupplierRepo : ISupplierRepo
    {
        // Constructor
        public SupplierRepo(DBContext context)
        {
            _dbc = context;
        }

        // Privates
        private DBContext _dbc;

        /// <summary>
        /// Returns all Suppliers from the database
        /// </summary>
        /// <returns>Task of IEnumerable of Suppliers (async)</returns>
        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            var query = from s in _dbc.Suppliers
                        select s;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a specific supplier
        /// </summary>
        /// <param name="supplierId">The Id of the wanted supplier</param>
        /// <returns>Task of supplier (async)</returns>
        public async Task<Supplier?> GetSupplier(int supplierId)
        {
            return await _dbc.Suppliers.FindAsync(supplierId);
        }
        /// <summary>
        /// Adds a supplier to the database
        /// </summary>
        /// <param name="supplier">The supplier to add</param>
        public void AddSupplier(Supplier supplier)
        {
            _dbc.Suppliers.Add(supplier);
        }
        /// <summary>
        /// Connects a Supplier to a Book via the intermediate table
        /// </summary>
        /// <param name="supplierId">The ID of the supplier</param>
        /// <param name="ISBN">The ISBN number (Id) of the book</param>
        public void ConnectSupplierToBook(int supplierId, string ISBN)
        {
            Supplier? supplier = _dbc.Suppliers.Find(supplierId);
            Book? book = _dbc.Books.Find(ISBN);

            // Check if entities are existen
            if (supplier == null) throw new EntityNotFoundException(nameof(supplier));
            if (book == null) throw new EntityNotFoundException(nameof(book));

            // Add content to relationship
            supplier.Books.Add(book); // _dbc.Suppliers.Find(supplier).Books.Add(book);
        }
        /// <summary>
        /// Removes the connection between a supplier and an book
        /// </summary>
        /// <param name="supplierId">The id of the supplier</param>
        /// <param name="ISBN">Thep ISBN number (Id) of the book</param>
        public void RemoveSupplierFromBook(int supplierId, string ISBN)
        {
            Supplier? supplier = _dbc.Suppliers.Find(supplierId);
            Book? book = _dbc.Books.Find(ISBN);

            // Check if entities are existen
            if (supplier == null) throw new EntityNotFoundException(nameof(supplier));
            if (book == null) throw new EntityNotFoundException(nameof(book));

            supplier.Books.Remove(book);
        }
        /// <summary>
        /// Updates the values of a Supplier
        /// </summary>
        /// <param name="supplier">The supplier to update</param>
        public void UpdateSupplier(Supplier supplier)
        {
            _dbc.Suppliers.Update(supplier);
        }
        /// <summary>
        /// Removes a supplier from DB
        /// </summary>
        /// <param name="supplier">The supplier to remove</param>
        public void RemoveSupplier(Supplier supplier)
        {
            _dbc.Suppliers.Remove(supplier);
        }
    }
}
