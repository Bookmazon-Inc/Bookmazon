using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Interfaces.Repos
{
    public interface IStorageRepo
    {
        #region Storage
        // Get
        Task<IEnumerable<Storage>> GetAllStorages();
        Task<Storage?> GetStorage(string ISBN, int StorageLocationID);
        
        // Set
        void AddStorage(Storage storage);
        void UpdateStorage(Storage storage);
        void RemoveStorage(Storage storage);
        #endregion

        #region StorageLocation
        // Get
        Task<IEnumerable<StorageLocation>> GetAllStorageLocations();
        Task<StorageLocation> GetStorageLocation(int StorageLocationID);

        // Set
        void AddStorageLocation(StorageLocation storageLocation);
        void UpdateStorageLocation(StorageLocation storageLocation);
        void RemoveStorageLocation(StorageLocation storageLocation);
        #endregion
    }
}
