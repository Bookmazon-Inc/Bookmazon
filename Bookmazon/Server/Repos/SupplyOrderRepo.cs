using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces.Filter;
using Bookmazon.Server.Interfaces.Repos;
using Bookmazon.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmazon.Server.Repos
{
    public class SupplyOrderRepo : ISupplyOrderRepo
    {
        //Constructor
        public SupplyOrderRepo(DBContext context)
        {
            _dbc = context; ;
        }

        // Privates
        private DBContext _dbc;

        #region SupplyOrder
        // Get
        /// <summary>
        /// Returns all SupplyOrders from the Database. An optional filter can be added to narrow down the search.
        /// </summary>
        /// <param name="SupplyOrderFilter">An Optional filter</param>
        /// <returns>Task of IEnumarable of SupplyOrders (async)</returns>
        public async Task<IEnumerable<SupplyOrder>> GetAllSupplyOrders(ISupplyOrderFilter? SupplyOrderFilter)
        {
            var query = from co in _dbc.SupplyOrders
                        select co;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a spefific SupplyOrder
        /// </summary>
        /// <param name="SupplyOrderId">The Id of the SupplyOrder</param>
        /// <returns></returns>
        public async Task<SupplyOrder?> GetSupplyOrder(int SupplyOrderId)
        {
            return await _dbc.SupplyOrders.FindAsync();
        }

        // Set
        /// <summary>
        /// Adds a new SupplyOrder to the Database
        /// </summary>
        /// <param name="SupplyOrder">The Order to add</param>
        public void AddSupplyOrder(SupplyOrder SupplyOrder)
        {
            _dbc.SupplyOrders.Add(SupplyOrder);
        }
        /// <summary>
        /// Updates the values of a SupplyOrder
        /// </summary>
        /// <param name="SupplyOrder">The order to update</param>
        public void UpdateSupplyOrder(SupplyOrder SupplyOrder)
        {
            _dbc.SupplyOrders.Update(SupplyOrder);
        }
        /// <summary>
        /// Removes a SupplyOrder from the database
        /// </summary>
        /// <param name="SupplyOrder"></param>
        public void RemoveSupplyOrder(SupplyOrder SupplyOrder)
        {
            _dbc.SupplyOrders.Remove(SupplyOrder);
        }
        #endregion

        #region SupplyOrderState
        // Get
        /// <summary>
        /// Returns all SupplyOrders in the Database
        /// </summary>
        /// <returns>Task of IEnum of SupplyOrderStates (async)</returns>
        public async Task<IEnumerable<SupplyOrderState>> GetAllSupplyOrdersState()
        {
            var query = from cos in _dbc.SupplyOrderStates
                        select cos;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a specific SupplyOrderState
        /// </summary>
        /// <param name="SupplyOrderStateId">The id of the state</param>
        /// <returns>Task of SupplyOrderState</returns>
        public async Task<SupplyOrderState> GetSupplyOrderState(int SupplyOrderStateId)
        {
            return await _dbc.SupplyOrderStates.FindAsync(SupplyOrderStateId);
        }

        // Set
        /// <summary>
        /// Adds a SupplyOrderState to the database
        /// </summary>
        /// <param name="SupplyOrderState">The State to add</param>
        public void AddSupplyOrderState(SupplyOrderState SupplyOrderState)
        {
            _dbc.SupplyOrderStates.Add(SupplyOrderState);
        }
        /// <summary>
        /// Updates the values of a SupplyOrderState
        /// </summary>
        /// <param name="SupplyOrderState">The state to update</param>
        public void UpdateSupplyOrderState(SupplyOrderState SupplyOrderState)
        {
            _dbc.SupplyOrderStates.Update(SupplyOrderState);
        }
        /// <summary>
        /// Removes a SupplyOrderState from the database
        /// </summary>
        /// <param name="SupplyOrderState">The state to remove</param>
        public void RemoveSupplyOrderState(SupplyOrderState SupplyOrderState)
        {
            _dbc.SupplyOrderStates.Remove(SupplyOrderState);
        }
        #endregion

        #region SupplyOrderPositions
        // Get
        /// <summary>
        /// Returns all SupplyOrderPositions from the Database
        /// </summary>
        /// <returns>Task of IEnum of SupplyOrderPositions</returns>
        public async Task<IEnumerable<SupplyOrderPosition>> GetAllSupplyOrderPositions()
        {
            var query = from cop in _dbc.SupplyOrderPositions
                        select cop;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns all Positions of a specific Order
        /// </summary>
        /// <param name="SupplyOrderId">The Id of the order to select positions from</param>
        /// <returns>Task of IEnum of SupplyOrderPositions (async)</returns>
        public async Task<IEnumerable<SupplyOrderPosition>> GetAllPositionsOfOrder(int SupplyOrderId)
        {
            var query = from cop in _dbc.SupplyOrderPositions
                        where cop.SuppllyOrderID == SupplyOrderId
                        select cop;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a specific SupplyOrderPosition
        /// </summary>
        /// <param name="SupplyOrderPositionId">The OrderPosId of the OrderPos</param>
        /// <param name="SupplyOrderId">The OrderId of the OrderPos</param>
        /// <returns></returns>
        public async Task<SupplyOrderPosition> GetSupplyOrderPosition(int SupplyOrderPositionId, int SupplyOrderId)
        {
            var query = from cop in _dbc.SupplyOrderPositions
                        where cop.SupplyOrderPositionID == SupplyOrderPositionId
                        where cop.SuppllyOrderID == SupplyOrderId
                        select cop;

            return await query.FirstAsync();
        }

        // Set
        /// <summary>
        /// Adds a SupplyOrderPosition to the database
        /// </summary>
        /// <param name="SupplyOrderPosition">The Position to add</param>
        public void AddSupplyOrderPosition(SupplyOrderPosition SupplyOrderPosition)
        {
            _dbc.SupplyOrderPositions.Add(SupplyOrderPosition);
        }
        /// <summary>
        /// Updates the values of a SupplyOrderPosition
        /// </summary>
        /// <param name="SupplyOrderPosition">The Position the update</param>
        public void UpdateSupplyOrderPosition(SupplyOrderPosition SupplyOrderPosition)
        {
            _dbc.SupplyOrderPositions.Update(SupplyOrderPosition);
        }
        /// <summary>
        /// Removes a SupplyOrderPosition from the database
        /// </summary>
        /// <param name="SupplyOrderPosition">The position to remove</param>
        public void RemoveSupplyOrderPosition(SupplyOrderPosition SupplyOrderPosition)
        {
            _dbc.SupplyOrderPositions.Remove(SupplyOrderPosition);
        }
        #endregion

        #region SupplyOrderPositionState (27 letters, new record)
        // Get
        /// <summary>
        /// Returns all SupplyOrderPositionStates that exit in the database
        /// </summary>
        /// <returns>Task of IEnum of SupplyOrderPositionState (async) </returns>
        public async Task<IEnumerable<SupplyOrderPositionState>> GetSupplyOrderPositionStates()
        {
            var query = from cops in _dbc.SupplyOrderPositionStates
                        select cops;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a specific SupplyOrderPositionState (puh)
        /// </summary>
        /// <param name="SupplyOrderPositonStateId">The Id of the PositionState</param>
        /// <returns></returns>
        public async Task<SupplyOrderPositionState> GetSupplyOrderPositionState(int SupplyOrderPositonStateId)
        {
            return await _dbc.SupplyOrderPositionStates.FindAsync(SupplyOrderPositonStateId);
        }

        // Set
        /// <summary>
        /// Adds a new SupplyOrderPositionState to the database
        /// </summary>
        /// <param name="SupplyOrderPositionState">The PositionState to add</param>
        public void AddSupplyOrderPositonState(SupplyOrderPositionState SupplyOrderPositionState)
        {
            _dbc.SupplyOrderPositionStates.Add(SupplyOrderPositionState);
        }
        /// <summary>
        /// Updates the values of a SupplyOrderPositionState
        /// </summary>
        /// <param name="SupplyOrderPositionStates">The PositionState to update </param>
        public void UpdateSupplyOrderPositionStates(SupplyOrderPositionState SupplyOrderPositionStates)
        {
            _dbc.SupplyOrderPositionStates.Update(SupplyOrderPositionStates);
        }
        /// <summary>
        /// Removes a SupplyOrderPositionState from the database
        /// </summary>
        /// <param name="SupplyOrderPositionState">THe PositonState to remove</param>
        public void RemoveSupplyOrderPositonState(SupplyOrderPositionState SupplyOrderPositionState)
        {
            _dbc.SupplyOrderPositionStates.Remove(SupplyOrderPositionState);
        }
        #endregion
    }
}
