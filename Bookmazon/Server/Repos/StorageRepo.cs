using Bookmazon.Server.Data;
using Bookmazon.Server.Interfaces.Repos;
using Bookmazon.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Bookmazon.Server.Repos
{
    

    public class StorageRepo : IStorageRepo
    {
        // Constructor
        public StorageRepo(DBContext context)
        {
            _dbc = context;
        }

        // Privates
        private DBContext _dbc;

        #region Storage
        // Get
        /// <summary>
        /// Returns everything in storage 
        /// </summary>
        /// <returns>Task of IEnum of Storage (async)</returns>
        public async Task<IEnumerable<Storage>> GetAllStorages()
        {
            var query = from s in _dbc.Storages
                        select s;

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// Returns a specific storage
        /// </summary>
        /// <param name="ISBN">The ISBN </param>
        /// <param name="StorageLocationID"></param>
        /// <returns></returns>
        public async Task<Storage?> GetStorage(string ISBN, int StorageLocationID) { 
            var query = from s in _dbc.Storages
                        where s.StorageLocationID == StorageLocationID
                        where s.ISBN == ISBN
                        select s;

            return await query.FirstAsync();
        }

        // Set
        /// <summary>
        /// Adds a new Storage to the Database
        /// </summary>
        /// <param name="storage">The storage to add</param>
        public void AddStorage(Storage storage)
        {
            _dbc.Storages.Add(storage);
        }
        /// <summary>
        /// Updates the values of a storage
        /// </summary>
        /// <param name="storage">The storage to update</param>
        public void UpdateStorage(Storage storage)
        {
            _dbc.Storages.Update(storage);
        }
        /// <summary>
        /// Removes a storage from the DB
        /// </summary>
        /// <param name="storage">The storage to remove</param>
        public void RemoveStorage(Storage storage) 
        { 
            _dbc.Storages.Remove(storage);
        }
        #endregion

        #region StorageLocation
        // Get
        /// <summary>
        /// Returns all StorageLocations in the Database
        /// </summary>
        /// <returns>Task of IEnum of StorageLocations (async)</returns>
        public async Task<IEnumerable<StorageLocation>> GetAllStorageLocations()
        {
            var query = from sl in _dbc.StorageLocations
                        select sl;

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Returns a specific StorageLocation
        /// </summary>
        /// <param name="StorageLocationID">The ID of the StorageLocation</param>
        /// <returns>Task of Storagelocation (async)</returns>
        public async Task<StorageLocation> GetStorageLocation(int StorageLocationID)
        {
            return await _dbc.StorageLocations.FindAsync(StorageLocationID);
        }

        // Set
        /// <summary>
        /// Addes a StorageLocation to the Database
        /// </summary>
        /// <param name="storageLocation">The StorageLocation to add</param>
        public void AddStorageLocation(StorageLocation storageLocation)
        {
            _dbc.StorageLocations.Add(storageLocation);
        }
        /// <summary>
        /// Updates the values of a StorageLocation
        /// </summary>
        /// <param name="storageLocation">The StorageLocation to update</param>
        public void UpdateStorageLocation(StorageLocation storageLocation)
        {
            _dbc.StorageLocations.Update(storageLocation);
        }
        /// <summary>
        /// Removes a StorageLocation from the DB
        /// </summary>
        /// <param name="storageLocation">The StorageLocation to remove</param>
        public void RemoveStorageLocation(StorageLocation storageLocation)
        {
            _dbc.StorageLocations.Remove(storageLocation);
        }
        #endregion
    }
}
