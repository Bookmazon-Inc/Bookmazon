using Bookmazon.Server.Interfaces.Repos;

namespace Bookmazon.Server.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepo UserRepo { get; }

        IBookRepo BookRepo { get; }

        ISupplierRepo SupplierRepo { get; }
        
        ICustomerOrderRepo customerOrderRepo { get; }

        IDiscountRepo discountRepo { get; }

        IInvoiceRepo invoiceRepo { get; }

        IStorageRepo storageRepo { get; }

        ISupplyOrderRepo supplyOrderRepo { get; }
    }
}
