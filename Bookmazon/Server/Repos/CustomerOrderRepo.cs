using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces.Filter;
using Bookmazon.Server.Interfaces.Repos;
using Bookmazon.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmazon.Server.Repos
{
    public class CustomerOrderRepo : ICustomerOrderRepo
    {
        //Constructor
        public CustomerOrderRepo (DBContext context)
        {
            _dbc = context; ;
        }

        // Privates
        private DBContext _dbc;

        #region CustomerOrder
        // Get
        /// <summary>
        /// Returns all CustomerOrders from the Database. An optional filter can be added to narrow down the search.
        /// </summary>
        /// <param name="customerOrderFilter">An Optional filter</param>
        /// <returns>Task of IEnumarable of CustomerOrders (async)</returns>
        public async Task<IEnumerable<CustomerOrder>> GetAllCustomerOrders(ICustomerOrderFilter? customerOrderFilter)
        {
            var query = from co in _dbc.CustomerOrders
                        select co;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a spefific CustomerOrder
        /// </summary>
        /// <param name="CustomerOrderId">The Id of the customerOrder</param>
        /// <returns></returns>
        public async Task<CustomerOrder?> GetCustomerOrder(int CustomerOrderId)
        {
            return await _dbc.CustomerOrders.FindAsync();
        }

        // Set
        /// <summary>
        /// Adds a new CustomerOrder to the Database
        /// </summary>
        /// <param name="customerOrder">The Order to add</param>
        public void AddCustomerOrder(CustomerOrder customerOrder)
        {
            _dbc.CustomerOrders.Add(customerOrder);
        }
        /// <summary>
        /// Updates the values of a customerOrder
        /// </summary>
        /// <param name="customerOrder">The order to update</param>
        public void UpdateCustomerOrder(CustomerOrder customerOrder)
        {
            _dbc.CustomerOrders.Update(customerOrder);
        }
        /// <summary>
        /// Removes a customerOrder from the database
        /// </summary>
        /// <param name="customerOrder"></param>
        public void RemoveCustomerOrder(CustomerOrder customerOrder)
        {
            _dbc.CustomerOrders.Remove(customerOrder);
        }
        #endregion

        #region CustomerOrderState
        // Get
        /// <summary>
        /// Returns all CustomerOrders in the Database
        /// </summary>
        /// <returns>Task of IEnum of CustomerOrderStates (async)</returns>
        public async Task<IEnumerable<CustomerOrderState>> GetAllCustomerOrdersState()
        {
            var query = from cos in _dbc.CustomerOrderStates
                        select cos;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a specific CustomerOrderState
        /// </summary>
        /// <param name="CustomerOrderStateId">The id of the state</param>
        /// <returns>Task of CustomerOrderState</returns>
        public async Task<CustomerOrderState> GetCustomerOrderState(int CustomerOrderStateId)
        {
            return await _dbc.CustomerOrderStates.FindAsync(CustomerOrderStateId);
        }

        // Set
        /// <summary>
        /// Adds a customerOrderState to the database
        /// </summary>
        /// <param name="customerOrderState">The State to add</param>
        public void AddCustomerOrderState(CustomerOrderState customerOrderState)
        {
            _dbc.CustomerOrderStates.Add(customerOrderState);
        }
        /// <summary>
        /// Updates the values of a customerOrderState
        /// </summary>
        /// <param name="customerOrderState">The state to update</param>
        public void UpdateCustomerOrderState(CustomerOrderState customerOrderState)
        {
            _dbc.CustomerOrderStates.Update(customerOrderState);
        }
        /// <summary>
        /// Removes a customerOrderState from the database
        /// </summary>
        /// <param name="customerOrderState">The state to remove</param>
        public void RemoveCustomerOrderState(CustomerOrderState customerOrderState)
        {
            _dbc.CustomerOrderStates.Remove(customerOrderState);
        }
        #endregion

        #region CustomerOrderPositions
        // Get
        /// <summary>
        /// Returns all CustomerOrderPositions from the Database
        /// </summary>
        /// <returns>Task of IEnum of CustomerOrderPositions</returns>
        public async Task<IEnumerable<CustomerOrderPosition>> GetAllCustomerOrderPositions()
        {
            var query = from cop in _dbc.CustomerOrderPositions
                        select cop;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns all Positions of a specific Order
        /// </summary>
        /// <param name="CustomerOrderId">The Id of the order to select positions from</param>
        /// <returns>Task of IEnum of CustomerOrderPositions (async)</returns>
        public async Task<IEnumerable<CustomerOrderPosition>> GetAllPositionsOfOrder(int CustomerOrderId)
        {
            var query = from cop in _dbc.CustomerOrderPositions
                        where cop.CustomerOrderID == CustomerOrderId
                        select cop;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a specific customerOrderPosition
        /// </summary>
        /// <param name="CustomerOrderPositionId">The OrderPosId of the OrderPos</param>
        /// <param name="CustomerOrderId">The OrderId of the OrderPos</param>
        /// <returns></returns>
        public async Task<CustomerOrderPosition> GetCustomerOrderPosition(int CustomerOrderPositionId, int CustomerOrderId)
        {
            var query = from cop in _dbc.CustomerOrderPositions
                        where cop.CustomerOrderPositionID == CustomerOrderPositionId
                        where cop.CustomerOrderID == CustomerOrderId
                        select cop;

            return await query.FirstAsync();
        }

        // Set
        /// <summary>
        /// Adds a CustomerOrderPosition to the database
        /// </summary>
        /// <param name="customerOrderPosition">The Position to add</param>
        public void AddCustomerOrderPosition(CustomerOrderPosition customerOrderPosition)
        {
            _dbc.CustomerOrderPositions.Add(customerOrderPosition);
        }
        /// <summary>
        /// Updates the values of a CustomerOrderPosition
        /// </summary>
        /// <param name="customerOrderPosition">The Position the update</param>
        public void UpdateCustomerOrderPosition(CustomerOrderPosition customerOrderPosition)
        {
            _dbc.CustomerOrderPositions.Update(customerOrderPosition);
        }
        /// <summary>
        /// Removes a CustomerOrderPosition from the database
        /// </summary>
        /// <param name="customerOrderPosition">The position to remove</param>
        public void RemoveCustomerOrderPosition(CustomerOrderPosition customerOrderPosition)
        {
            _dbc.CustomerOrderPositions.Remove(customerOrderPosition);
        }
        #endregion

        #region CustomerOrderPositionState (27 letters, new record)
        // Get
        /// <summary>
        /// Returns all CustomerOrderPositionStates that exit in the database
        /// </summary>
        /// <returns>Task of IEnum of CustomerOrderPositionState (async) </returns>
        public async Task<IEnumerable<CustomerOrderPositionState>> GetCustomerOrderPositionStates()
        {
            var query = from cops in _dbc.CustomerOrderPositionStates
                        select cops;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a specific CustomerOrderPositionState (puh)
        /// </summary>
        /// <param name="customerOrderPositonStateId">The Id of the PositionState</param>
        /// <returns></returns>
        public async Task<CustomerOrderPositionState> GetCustomerOrderPositionState(int customerOrderPositonStateId)
        {
            return await _dbc.CustomerOrderPositionStates.FindAsync(customerOrderPositonStateId);
        }

        // Set
        /// <summary>
        /// Adds a new CustomerOrderPositionState to the database
        /// </summary>
        /// <param name="customerOrderPositionState">The PositionState to add</param>
        public void AddCustomerOrderPositonState(CustomerOrderPositionState customerOrderPositionState)
        {
            _dbc.CustomerOrderPositionStates.Add(customerOrderPositionState);
        }
        /// <summary>
        /// Updates the values of a CustomerOrderPositionState
        /// </summary>
        /// <param name="customerOrderPositionStates">The PositionState to update </param>
        public void UpdateCustomerOrderPositionStates(CustomerOrderPositionState customerOrderPositionStates)
        {
            _dbc.CustomerOrderPositionStates.Update(customerOrderPositionStates);
        }
        /// <summary>
        /// Removes a CustomerOrderPositionState from the database
        /// </summary>
        /// <param name="customerOrderPositionState">THe PositonState to remove</param>
        public void RemoveCustomerOrderPositonState(CustomerOrderPositionState customerOrderPositionState)
        {
            _dbc.CustomerOrderPositionStates.Remove(customerOrderPositionState);
        }
        #endregion
    }
}
