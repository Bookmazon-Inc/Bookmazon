﻿using Bookmazon.Server.Interfaces;
using Bookmazon.Server.Interfaces.Repos;
using Bookmazon.Server.Repos;

namespace Bookmazon.Server.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private DBContext _dbContext;


        public UnitOfWork(DBContext dBContext)
        {
            _dbContext = dBContext;
        }


        private IUserRepo _userReo;
        public IUserRepo UserRepo => _userReo ??= new UserRepo(_dbContext);

        private IBookRepo _bookRepo;
        public IBookRepo BookRepo => _bookRepo ??= new BookRepo(_dbContext);

        private ISupplierRepo _supplierRepo;
        public ISupplierRepo SupplierRepo => _supplierRepo ??= new SupplierRepo(_dbContext);

        public ICustomerOrderRepo customerOrderRepo => throw new NotImplementedException();

        public IDiscountRepo discountRepo => throw new NotImplementedException();

        public IInvoiceRepo invoiceRepo => throw new NotImplementedException();

        public IStorageRepo storageRepo => throw new NotImplementedException();

        public ISupplyOrderRepo _supplyOrderRepo;
        public ISupplyOrderRepo supplyOrderRepo => _supplyOrderRepo ??= new SupplyOrderRepo(_dbContext);

        #region Functions
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public async void CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
