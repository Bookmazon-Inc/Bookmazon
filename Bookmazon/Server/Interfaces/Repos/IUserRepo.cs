using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Interfaces.Repos
{
    public interface IUserRepo
    {
        #region User
        // Get
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUser(int userId);

        // Set
        void AddUser(User user);
        void ConnectUserToRole(int userId, int roleID);
        void RemoveUserFromRole(int userId, int roleID);
        void UpdateUser(User user);
        void DeleteUser(User user);
        #endregion

        #region Roles
        // Get
        Task<IEnumerable<Roles>> GetAllRoles();
        Task<Roles> GetRole(int roleId);

        // Set
        void AddRole(Roles role);
        void UpdateRole(Roles role);
        void DeleteRole(Roles role);
        #endregion
    }
}