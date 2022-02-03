using Bookmazon.Server.Filter;
using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Interfaces.Repos
{
    public interface ICustomerOrderRepo
    {
        #region CustomerOrder
        // Get
        Task<IEnumerable<CustomerOrder>> GetAllCustomerOrders(CustomerOrderFilter? customerOrderFilter);
        Task<CustomerOrder?> GetCustomerOrder(int CustomerOrderId);
        Task<IEnumerable<CustomerOrder>> GetOrdersFromCustomer(int customerID);

        // Set
        void AddCustomerOrder(CustomerOrder customerOrder);
        void UpdateCustomerOrder(CustomerOrder customerOrder);
        void RemoveCustomerOrder(CustomerOrder customerOrder);
        #endregion

        #region CustomerOrderState
        // Get
        Task<IEnumerable<CustomerOrderState>> GetAllCustomerOrdersState();
        Task<CustomerOrderState> GetCustomerOrderState(int CustomerOrderStateId);

        // Set
        void AddCustomerOrderState(CustomerOrderState customerOrderState);
        void UpdateCustomerOrderState(CustomerOrderState customerOrderState);
        void RemoveCustomerOrderState(CustomerOrderState customerOrderState);
        #endregion

        #region CustomerOrderPositions
        // Get
        Task<IEnumerable<CustomerOrderPosition>> GetAllCustomerOrderPositions();
        Task<CustomerOrderPosition> GetCustomerOrderPosition(int CustomerOrderPositionId, int CustomerOrderID);

        // Set
        void AddCustomerOrderPosition(CustomerOrderPosition customerOrderPosition);
        void UpdateCustomerOrderPosition(CustomerOrderPosition customerOrderPosition);
        void RemoveCustomerOrderPosition(CustomerOrderPosition customerOrderPosition);
        #endregion

        #region CustomerOrderPositionState
        // Get
        Task<IEnumerable<CustomerOrderPositionState>> GetCustomerOrderPositionStates();
        Task<CustomerOrderPositionState> GetCustomerOrderPositionState(int customerOrderPositonStateId);

        // Set
        void AddCustomerOrderPositonState(CustomerOrderPositionState customerOrderPositionState);
        void UpdateCustomerOrderPositionStates(CustomerOrderPositionState customerOrderPositionStates);
        void RemoveCustomerOrderPositonState(CustomerOrderPositionState customerOrderPositionState);
        #endregion
    }
}
