using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Interfaces
{
    public interface ISupplierRepo
    {
        // Get
        Task<IEnumerable<Supplier>> GetAll();
        Task<Supplier> Get(int supplierId);

        // Set
        void Add(Supplier supplier);
        void Update(Supplier supplier);
        void Remove(Supplier supplier);

        // ViewModels
        
    }
}
