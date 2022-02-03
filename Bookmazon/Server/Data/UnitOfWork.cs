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


        private IUserRepo _userRepo;
        public IUserRepo UserRepo => _userRepo ??= new UserRepo(_dbContext);

        private IBookRepo _bookRepo;
        public IBookRepo BookRepo => _bookRepo ??= new BookRepo(_dbContext);

        public ISupplierRepo SupplierRepo => throw new NotImplementedException();

        private ICustomerOrderRepo _customerOrderRepo;
        public ICustomerOrderRepo customerOrderRepo => _customerOrderRepo ??= new CustomerOrderRepo(_dbContext);

        public IDiscountRepo discountRepo => throw new NotImplementedException();

        public IInvoiceRepo invoiceRepo => throw new NotImplementedException();

        public IStorageRepo storageRepo => throw new NotImplementedException();

        public ISupplyOrderRepo supplyOrderRepo => throw new NotImplementedException();

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
