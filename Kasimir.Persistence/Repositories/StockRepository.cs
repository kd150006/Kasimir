using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Persistence.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StockRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Stock stock)
        {
            _dbContext.Add(stock);
        }

        public void AddRange(IEnumerable<Stock> stock)
        {
            _dbContext.AddRange(stock);
        }

        public void Delete(Stock stock)
        {
            _dbContext.Remove(stock);
        }

        public IEnumerable<Stock> GetAll()
        {
            return _dbContext.Stocks;
        }

        public Stock GetById(int id)
        {
            return _dbContext.Stocks.Find(id);
        }

        public IEnumerable<Stock> GetByName(string name)
        {
            return _dbContext.Stocks.Where(stock => stock.Name == name);
        }

        public IEnumerable<Stock> GetByStatus(string status)
        {
            return _dbContext.Stocks.Where(stock => stock.Status == status);
        }

        public int GetQuantityOfAllStocks()
        {
            var stockQuantity = _dbContext.Stocks
                .Where(stock => stock.Status != ItemStatus.Deleted)                
                .GroupBy(stock => stock.Id)
                .Count();
            return (stockQuantity);
        }

        public int GetQuantityOfStockById(int id)
        {
            return _dbContext.Stocks                
                .Where(stock => stock.Id.Equals(id))
                .Count();
        }

        public void Update(Stock stock)
        {
            _dbContext.Update(stock);
        }
    }
}
