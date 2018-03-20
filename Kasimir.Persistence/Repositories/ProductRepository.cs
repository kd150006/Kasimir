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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Product product)
        {
            await _dbContext.AddAsync(product);            
        }

        public async Task AddRange(List<Product> products)
        {
            await _dbContext.AddRangeAsync(products);
        }

        public void Delete(Product product)
        {
            _dbContext.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products
                .Include(product => product.Stock)
                .Where(product => product.Status != ItemStatus.Deleted)
                .OrderBy(product => product.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByStockId(int id)
        {
            return await _dbContext.Products
                .Where(product => product.StockId == id)
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products
                .Include(product => product.Stock)
                .Where(product => product.Status != ItemStatus.Deleted && product.Id == id)
                .SingleOrDefaultAsync();

        }

        public async Task<IEnumerable<Product>> GetBySearchTerm(string searchTerm)
        {
            return await _dbContext.Products
                .Where(product => product.Status != ItemStatus.Deleted &&
                    (product.Name.Contains(searchTerm) || product.Number.Contains(searchTerm) || product.Barcode.Contains(searchTerm)))
                    .ToListAsync();
        }

        public async Task<int> GetTotalStockQty(int id)
        {
            return await _dbContext.Products
                .Include(product => product.Stock)
                .Where(productStock => productStock.Stock.Id == id)
                .SumAsync(product => product.Quantity ?? 0);
        }

        public void Update(Product product)
        {
            _dbContext.Update(product);
        }
    }
}
