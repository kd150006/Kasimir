using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Persistence.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StockRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Stock stock)
        {
            await _dbContext.AddAsync(stock);
        }

        public async Task AddRange(IEnumerable<Stock> stock)
        {
            await _dbContext.AddRangeAsync(stock);
        }

        public void Delete(Stock stock)
        {
            _dbContext.Remove(stock);
        }

        public async Task<IEnumerable<Stock>> GetAll()
        {
            return await _dbContext.Stocks.ToListAsync();
        }

        public async Task<Stock> GetById(int id)
        {
            return await _dbContext.Stocks.FindAsync(id);
        }

        public async Task<IEnumerable<Stock>> GetByName(string name)
        {
            return await _dbContext.Stocks.Where(stock => stock.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Stock>> GetByStatus(string status)
        {
            return await _dbContext.Stocks.Where(stock => stock.Status == status).ToListAsync();
        }

        public async Task<int> GetQuantityOfAllStocks()
        {
            var stockQuantity = await _dbContext.Stocks
                .Where(stock => stock.Status != ItemStatus.Deleted)
                .GroupBy(stock => stock.Id)
                .CountAsync();
            return (stockQuantity);
        }

        public Task<int> GetQuantityOfStockById(int id)
        {
            return _dbContext.Stocks                
                .Where(stock => stock.Id.Equals(id))
                .CountAsync();
        }

        public void Update(Stock stock)
        {
            _dbContext.Update(stock);
        }
    }
}
