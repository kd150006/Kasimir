using Kasimir.Core.Contracts;
using Kasimir.Persistence;
using Kasimir.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _isDisposed;
        public UnitOfWork()
        {
            _dbContext = new ApplicationDbContext();
            BasketDetailRepository = new BasketDetailRepository(_dbContext);
            BasketHeaderRepository = new BasketHeaderRepository(_dbContext);
            CashDrawerRepository = new CashDrawerRepository(_dbContext);
            CustomerRepository = new CustomerRepository(_dbContext);
            JournalRepository = new JournalRepository(_dbContext);
            MeansOfPaymentRepository = new MeansOfPaymentRepository(_dbContext);
            ProductRepository = new ProductRepository(_dbContext);            
            StockRepository = new StockRepository(_dbContext);
            UserRepository = new UserRepository(_dbContext);            
        }
        public IBasketDetailRepository BasketDetailRepository { get; }
        public IBasketHeaderRepository BasketHeaderRepository { get; }       
        public ICashDrawerRepository CashDrawerRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IJournalRepository JournalRepository { get; }
        public IMeansOfPaymentRepository MeansOfPaymentRepository { get; }
        public IProductRepository ProductRepository { get; }        
        public IStockRepository StockRepository { get; }
        public IUserRepository UserRepository { get; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void CreateDatabase()
        {
            _dbContext.Database.EnsureCreated();
        }

        public void DeleteDatabase()
        {
            _dbContext.Database.EnsureDeleted();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void InitializeDatabase()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.Migrate();
        }
    }
}
