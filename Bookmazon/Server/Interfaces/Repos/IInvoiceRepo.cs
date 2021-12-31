using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Interfaces.Repos
{
    public interface IInvoiceRepo
    {
        #region Invoice
        Task<Invoice?> GetInvoice(int invoiceID);
        Task<IEnumerable<Invoice>> GetAllInvoices();
        void AddInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);

        #endregion

        #region InvoicePositions
        Task<InvoicePosition?> GetInvoicePosition(int invoicePositionID, int invoiceId);
        Task<IEnumerable<InvoicePosition>> GetAllInvoicePositions();
        void AddInvoicePosition(InvoicePosition invoicePosition);
        void UpdateInvoicePosition(InvoicePosition invoicePosition);
        void DeleteInvoicePosition(InvoicePosition invoicePosition);

        #endregion

        #region InvoiceState
        Task<InvoiceState?> GetInvoiceState(int invoiceStateID);
        Task<IEnumerable<InvoiceState>> GetAllInvoicesStates();
        void AddInvoiceState(InvoiceState invoiceState);
        void UpdateInvoiceState(InvoiceState invoiceState);
        void DeleteInvoiceState(InvoiceState invoiceState);
        #endregion

    }
}
