using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IBasketRepository BasketHeaderRepository { get; }
        ICashDrawerRepository CashDrawerRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IJournalRepository JournalRepository { get; }
        IMeansOfPaymentRepository MeansOfPaymentRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        IStockRepository StockRepository { get; }
        IUserRepository UserRepository { get; }

        void Save();
        void InitializeDatabase();
    }
}

