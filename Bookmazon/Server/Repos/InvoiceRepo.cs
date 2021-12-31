using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces.Repos;
using Bookmazon.Shared.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Bookmazon.Server.Repos
{
    public class InvoiceRepo : IInvoiceRepo
    {
        // Constructorr
        public InvoiceRepo(DBInvoiceContext context)
        {
            _dbc = context;
        }
        
        // Privates
        private DBInvoiceContext _dbc;

        #region Invoice
        /// <summary>
        /// Returns a specific Invoice from the database
        /// </summary>
        /// <param name="invoiceID">The Id of the Invoice</param>
        /// <returns></returns>
        public async Task<Invoice?> GetInvoice(int invoiceID)
        {
            return await _dbc.Invoices.FindAsync(invoiceID);
        }
        /// <summary>
        /// Returns all Invoices from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            var query = from i in _dbc.Invoices
                        select i;

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// Adds a new Invoice to the database
        /// </summary>
        /// <param name="invoice"></param>
        public void AddInvoice(Invoice invoice)
        {
            _dbc.Invoices.Add(invoice);
        }
        /// <summary>
        /// Updates the values of a invoice in the database (should not be needed because values of invoices SHOULD NEVER BE CHANGED, NEVER) 
        /// </summary>
        /// <param name="invoice"></param>
        public void UpdateInvoice(Invoice invoice) 
        { 
            _dbc.Invoices.Update(invoice); 
        }
        /// <summary>
        /// Removes a Invoice from the database (should only be used after 7 years since creation of invoice, invoice ARE NOT ALLOWED TO BE DELETED ANY SOONER)
        /// </summary>
        /// <param name="invoice"></param>
        public void DeleteInvoice(Invoice invoice)
        {
            _dbc.Invoices.Remove(invoice);
        }
        #endregion

        #region InvoicePositions
        /// <summary>
        /// Returns a specific InvoicePosition from the database
        /// </summary>
        /// <param name="invoicePositionID">The PositionId of the invoice</param>
        /// <param name="invoiceId">The Id of the invoice</param>
        /// <returns></returns>
        public async Task<InvoicePosition?> GetInvoicePosition(int invoicePositionID, int invoiceId)
        {
            var query = from invPos in _dbc.InvoicePositions
                        where invPos.InvoiceID == invoiceId
                        where invPos.InvoicePositionID == invoicePositionID
                        select invPos;

            return await query.FirstAsync();
        }
        /// <summary>
        /// Returns all InvoicePositions from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<InvoicePosition>> GetAllInvoicePositions()
        {
            var query = from invPos in _dbc.InvoicePositions
                        select invPos;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns all InvoicePositions of a specific Invoice
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<InvoicePosition>> GetAllPositionsFromInvoice(int invoiceId)
        {
            var query = from invPos in _dbc.InvoicePositions
                        where invPos.InvoiceID == invoiceId
                        select invPos;

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// Adds an InvoicePosition to the database 
        /// </summary>
        /// <param name="invoicePosition"></param>
        public void AddInvoicePosition(InvoicePosition invoicePosition)
        {
            _dbc.InvoicePositions.Add(invoicePosition);
        }
        /// <summary>
        /// Updates the values of the given InvoicePosition (Another thing that should never happen because it isnt allowed)
        /// </summary>
        /// <param name="invoicePosition"></param>
        public void UpdateInvoicePosition(InvoicePosition invoicePosition)
        {
            _dbc.InvoicePositions.Update(invoicePosition);
        }
        /// <summary>
        /// Removes a InvoicePosition from the database (Another thing that should never happen because it isnt allowed)
        /// </summary>
        /// <param name="invoicePosition"></param>
        public void DeleteInvoicePosition(InvoicePosition invoicePosition) 
        { 
            _dbc.InvoicePositions.Remove(invoicePosition); 
        }

        #endregion

        #region InvoiceState
        /// <summary>
        /// Returns a specific InvoiceState
        /// </summary>
        /// <param name="invoiceStateID"></param>
        /// <returns></returns>
        public async Task<InvoiceState?> GetInvoiceState(int invoiceStateID)
        {
            return await _dbc.InvoiceStates.FindAsync(invoiceStateID);
        }
        /// <summary>
        /// Returns all InvoiceStates from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<InvoiceState>> GetAllInvoicesStates()
        {
            var query = from invSt in _dbc.InvoiceStates
                        select invSt;

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// Adds a InvoiceState to the database
        /// </summary>
        /// <param name="invoiceState"></param>
        public void AddInvoiceState(InvoiceState invoiceState)
        {
            _dbc.InvoiceStates.Add(invoiceState);
        }
        /// <summary>
        /// Updates the values of a InvoiceState (finally something legal)
        /// </summary>
        /// <param name="invoiceState"></param>
        public void UpdateInvoiceState(InvoiceState invoiceState)
        {
            _dbc.InvoiceStates.Update(invoiceState);
        }
        /// <summary>
        /// Removes an invoiceState from the database
        /// </summary>
        /// <param name="invoiceState"></param>
        public void DeleteInvoiceState(InvoiceState invoiceState)
        {
            _dbc.InvoiceStates.Remove(invoiceState);
        }
        #endregion




        #region HelperFunctions
        public void CreateInvoiceFromOrder(CustomerOrder customerOrder)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
