using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Core.Contracts
{
    public interface IStockRepository
    {
        Task Add(Stock stock);
        Task AddRange(IEnumerable<Stock> stock);
        void Update(Stock stock);
        void Delete(Stock stock);
        Task<IEnumerable<Stock>> GetAll();
        Task<Stock> GetById(int id);
        Task<IEnumerable<Stock>> GetByStatus(string status);
        Task<IEnumerable<Stock>> GetByName(string name);        
       Task<int> GetQuantityOfAllStocks();
        Task<int> GetQuantityOfStockById(int id);
    }
}
