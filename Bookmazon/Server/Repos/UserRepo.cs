using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces.Repos;
using Bookmazon.Server.Exceptions;
using Bookmazon.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bookmazon.Server.Repos
{
    public class UserRepo : IUserRepo
    {
        // Constructor
        public UserRepo(DBContext context)
        {
            _dbc = context;
        }

        // Common Privates
        private DBContext _dbc;

        // Privates for Password Hashing
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int Itterations = 100;
        #region User
        // Get
        /// <summary>
        /// Returns all Users of current database
        /// </summary>
        /// <returns>Task of IEnumerable of User (async)</returns>
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var query = from u in _dbc.Users
                        select u;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a sepcific user from the database
        /// </summary>
        /// <param name="userId">The Id of the user to return</param>
        /// <returns>Task of a user (async)</returns>
        public async Task<User?> GetUser(int userId)
        {
            return await _dbc.Users.FindAsync(userId);
        }

        // Set
        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="user">Ther user to add</param>
        public void AddUser(User user)
        {
            _dbc.Users.Add(user);
        }
        /// <summary>
        /// Adds a role to a user via the intermediate table
        /// </summary>
        /// <param name="userId">The Id of the user to connect to</param>
        /// <param name="roleID">THe Id of the role which should be connected to the user</param>
        /// /// <exception cref="EntityNotFoundException">This exception will be throw if no role or user has been found</exception>
        public void ConnectUserToRole(int userId, int roleId)
        {
            User user = _dbc.Users.Find(userId);
            Roles role = _dbc.Roles.Find(roleId);

            // Check if Role and User exist
            if (user == null) throw new EntityNotFoundException(nameof(user));
            if (role == null) throw new EntityNotFoundException(nameof(role));

            user.Roles.Add(role);
        }
        /// <summary>
        /// Removes the connection between a role and a user
        /// </summary>
        /// <param name="userId">The Id of the user</param>
        /// <param name="roleId">The Id of the role</param>
        /// <exception cref="EntityNotFoundException">This exception will be throw if no role or user has been found</exception>
        public void RemoveUserFromRole (int userId, int roleId)
        {
            User user = _dbc.Users.Find(userId);
            Roles role = _dbc.Roles.Find(roleId);

            // Check if Role and User exist
            if (user == null) throw new EntityNotFoundException(nameof(user));
            if (role == null) throw new EntityNotFoundException(nameof(role));

            user.Roles.Remove(role);
        }
        /// <summary>
        /// Updates the values of a User
        /// </summary>
        /// <param name="user">The user to update</param>
        public void UpdateUser(User user)
        {
            _dbc.Users.Update(user);
        }
        /// <summary>
        /// Removes a user from the datatable
        /// </summary>
        /// <param name="user">The user to remove</param>
        public void DeleteUser(User user)
        {
            _dbc.Remove(user);
        }
        #endregion

        #region Roles
        // Get
        /// <summary>
        /// Returns all Roles in the Database
        /// </summary>
        /// <returns>Task of IEnum of Roles (async)</returns>
        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            var query = from r in _dbc.Roles
                        select r;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a specific role in the database
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>Task of a role (async)</returns>
        public async Task<Roles> GetRole(int roleId)
        {
            return await _dbc.Roles.FindAsync(roleId);
        }

        // Set
        /// <summary>
        /// Adds a role the the database
        /// </summary>
        /// <param name="role">The role to add</param>
        public void AddRole(Roles role)
        {
            _dbc.Roles.Add(role);
        }
        /// <summary>
        /// Updates the values of a role
        /// </summary>
        /// <param name="role">The role to update</param>
        public void UpdateRole(Roles role)
        {
            _dbc.Roles.Update(role);
        }
        /// <summary>
        /// Removes a role from the database
        /// </summary>
        /// <param name="role">The role to remove</param>
        public void DeleteRole(Roles role)
        {
            _dbc.Roles.Remove(role);
        }
        #endregion



        #region Helper Functions
        // TODO: Talk about this section of code and decide how to do this 
        /// <summary>
        /// Hashes a password
        /// </summary>
        /// <param name="pwd">The password to hash</param>
        /// <returns>A hashed password</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string HashPwd(string pwd)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Verifies if a password is hashed correctly
        /// </summary>
        /// <param name="hpwd">The hashed pwd</param>
        /// <param name="user">The user to check the pwd</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool VerifyPwd(string hpwd, User user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
