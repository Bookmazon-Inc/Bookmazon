using Bookmazon.Server.Filter;
using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Interfaces.Repos
{
    public interface ISupplyOrderRepo
    {
        #region SupplyOrder
        // Get
        Task<IEnumerable<SupplyOrder>> GetAllSupplyOrders(SupplyOrderFilter? supplyOrderFilter);
        Task<SupplyOrder?> GetSupplyOrder(int SupplyOrderId);

        // Set
        void AddSupplyOrder(SupplyOrder SupplyOrder);
        void UpdateSupplyOrder(SupplyOrder SupplyOrder);
        void RemoveSupplyOrder(SupplyOrder SupplyOrder);
        #endregion

        #region SupplyOrderState
        // Get
        Task<IEnumerable<SupplyOrderState>> GetAllSupplyOrdersState();
        Task<SupplyOrderState> GetSupplyOrderState(int SupplyOrderStateId);

        // Set
        void AddSupplyOrderState(SupplyOrderState SupplyOrderState);
        void UpdateSupplyOrderState(SupplyOrderState SupplyOrderState);
        void RemoveSupplyOrderState(SupplyOrderPositionState SupplyOrderPositionState);
        #endregion

        #region SupplyOrderPositions
        // Get
        Task<IEnumerable<SupplyOrderPosition>> GetAllSupplyOrderPositions();
        Task<SupplyOrderPosition> GetSupplyOrderPosition(int SupplyOrderPositionId);

        // Set
        void AddSupplyOrderPosition(SupplyOrderPosition SupplyOrderPosition);
        void UpdateSupplyOrderPosition(SupplyOrderPosition SupplyOrderPosition);
        void RemoveSupplyOrderPosition(SupplyOrderPosition SupplyOrderPosition);
        #endregion

        #region SupplyOrderPositionState
        // Get
        Task<IEnumerable<SupplyOrderPositionState>> GetSupplyOrderPositionStates();
        Task<SupplyOrderPositionState> GetSupplyOrderPositionState(int SupplyOrderPositonStateId);

        // Set
        void AddSupplyOrderPositonState(SupplyOrderPositionState SupplyOrderPositionState);
        void UpdateSupplyOrderPositionStates(SupplyOrderPositionState SupplyOrderPositionStates);
        void RemoveSupplyOrderPositonState(SupplyOrderPositionState SupplyOrderPositionState);
        #endregion
    }
}
