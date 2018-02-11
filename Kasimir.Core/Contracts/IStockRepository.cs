using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface IStockRepository
    {
        void Add(Stock stock);
        void AddRange(IEnumerable<Stock> stock);
        void Update(Stock stock);
        void Delete(Stock stock);
        IEnumerable<Stock> GetAll();
        IEnumerable<Stock> GetById(int id);
        IEnumerable<Stock> GetByStatus(string status);
        IEnumerable<Stock> GetByName(string name);
        int GetQuantityOfAllStocks();
        int GetQuantityOfStockById(int id);
    }
}
