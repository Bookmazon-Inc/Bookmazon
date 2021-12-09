using Bookmazon.Shared.Models;
    
namespace Bookmazon.Server.Interfaces.Repos
{
    public interface ISupplierRepo
    {
        // Get 
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        Task<Supplier> GetSupplier(int supplierId);

        // Set
        void AddSupplier(Supplier supplier);
        void ConnectSupplierToBook(int supplierId, string ISBN);
        void UpdateSupplier(Supplier supplier);
        void RemoveSupplier(Supplier supplier);
    }
}
