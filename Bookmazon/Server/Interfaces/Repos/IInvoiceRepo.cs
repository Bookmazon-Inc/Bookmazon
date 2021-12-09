using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Interfaces.Repos
{
    public interface IInvoiceRepo
    {
        #region Invoice
        Task<Invoice?> GetInvoice(int invoiceID);
        Task<IEnumerable<Invoice>> GetAllInvoices();
        void AddGenre(Invoice invoice);
        void UpdateGenre(Invoice invoice);
        void DeleteGenre(Invoice invoice);

        #endregion

        #region InvoicePositions
        Task<InvoicePosition?> GetInvoicePosition(int invoicePositionID);
        Task<IEnumerable<InvoicePosition>> GetAllInvoicePositions();
        void AddGenre(InvoicePosition invoicePosition);
        void UpdateGenre(InvoicePosition invoicePosition);
        void DeleteGenre(InvoicePosition invoicePosition);

        #endregion

        #region InvoiceState
        Task<InvoiceState?> GetInvoiceState(int invoiceStateID);
        Task<IEnumerable<InvoiceState>> GetAllInvoicesStates();
        void AddGenre(InvoiceState invoiceState);
        void UpdateGenre(InvoiceState invoiceState);
        void DeleteGenre(InvoiceState invoiceState);

        #endregion

    }
}
