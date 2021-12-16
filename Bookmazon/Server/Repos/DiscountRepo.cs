using Bookmazon.Server.Data;
using Bookmazon.Server.Exceptions;
using Bookmazon.Server.Interfaces.Repos;
using Bookmazon.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmazon.Server.Repos
{
    public class DiscountRepo : IDiscountRepo
    {
        // Constructor
        public DiscountRepo (DBContext context)
        {
            _dbc = context;
        }

        // Privates
        private DBContext _dbc;
        
        // Get
        /// <summary>
        /// Returns all Discounts from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Discount>> GetAllDiscounts()
        {
            var query = from d in _dbc.Discounts
                        select d;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a specific Discount 
        /// </summary>
        /// <param name="Discountid">The Id of the wanted discount</param>
        /// <returns></returns>
        public async Task<Discount> GetDiscount(int Discountid)
        {
            return await _dbc.Discounts.FindAsync(Discountid);
        }

        // Set
        /// <summary>
        /// Adds a discount to the database
        /// </summary>
        /// <param name="discount">The discount to add</param>
        public void AddDiscount(Discount discount)
        {
            _dbc.Discounts.Add(discount);
        }
        /// <summary>
        /// Connets a discount to a book via the intermediate table
        /// </summary>
        /// <param name="ISBN">The ISBN number (Id) of the book</param>
        /// <param name="discountId">The Id of the discount</param>
        public void ConnectDiscountToBook(string ISBN, int discountId)
        {
            Book book = _dbc.Books.Find(ISBN);
            Discount discount = _dbc.Discounts.Find(discountId);

            // Check if Role and User exist
            if (book == null) throw new EntityNotFoundException(nameof(book));
            if (discount == null) throw new EntityNotFoundException(nameof(discount));

            book.Discounts.Add(discount);
        }
        /// <summary>
        /// Removes the connection between a book and a discount
        /// </summary>
        /// <param name="ISBN">The ISBN number (Id) of a book</param>
        /// <param name="discountId">The Id of the discount</param>
        public void RemoveDiscountFromBook(string ISBN, int discountId)
        {
            Book book = _dbc.Books.Find(ISBN);
            Discount discount = _dbc.Discounts.Find(discountId);

            // Check if Role and User exist
            if (book == null) throw new EntityNotFoundException(nameof(book));
            if (discount == null) throw new EntityNotFoundException(nameof(discount));

            book.Discounts.Remove(discount);
        }
        /// <summary>
        /// Updates the values of a discount
        /// </summary>
        /// <param name="discount"></param>
        public void UpdateDiscount(Discount discount)
        {
            _dbc.Discounts.Update(discount);
        }
        /// <summary>
        /// Removes a discount from the database
        /// </summary>
        /// <param name="discount">The discount to remove</param>
        public void RemoveDiscount(Discount discount)
        {
            _dbc.Discounts.Remove(discount);
        }
    }
}
