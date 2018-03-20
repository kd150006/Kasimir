﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IBasketDetailRepository BasketDetailRepository { get; }
        IBasketHeaderRepository BasketHeaderRepository { get; }
        ICashDrawerRepository CashDrawerRepository { get; }
        ICustomerRepository CustomerRepository { get; }                
        IProductRepository ProductRepository { get; }        
        IStockRepository StockRepository { get; }
        IUserRepository UserRepository { get; }

        Task Save();
        void InitializeDatabase();
    }
}

