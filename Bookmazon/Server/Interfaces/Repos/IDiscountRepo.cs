using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Interfaces.Repos
{
    public interface IDiscountRepo
    {
        // Get
        Task<IEnumerable<Discount>> GetAllDiscounts();
        Task<Discount> GetDiscount(int Discountid);

        // Set
        void AddDiscount(Discount discount);
        void ConnectDiscountToBook(string ISBN, int discountId);
        void RemoveDiscountFromBook(string ISBN, int discountId);
        void UpdateDiscount(Discount discount); 
        void RemoveDiscount(Discount discount);
    }
}
