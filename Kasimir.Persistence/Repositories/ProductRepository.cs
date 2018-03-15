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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Product product)
        {
            _dbContext.Add(product);
        }

        public void AddRange(List<Product> products)
        {
            _dbContext.AddRange(products);
        }

        public void Delete(Product product)
        {
            _dbContext.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products
                .Include(product => product.Stock)                    
                .Where(product => product.Status != ItemStatus.Deleted)
                .ToList();
        }

        public IEnumerable<Product> GetAllByStockId(int id)
        {
            return _dbContext.Products
                .Where(product => product.StockId == id)
                .ToList();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products
                .Include(product => product.Stock)                    
                .Where(product => product.Status != ItemStatus.Deleted && product.Id == id)
                .SingleOrDefault();
                
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return _dbContext.Products
                .Where(product => product.Status != ItemStatus.Deleted && product.Name.Contains(name))
                .ToList();
        }

        public IEnumerable<Product> GetByNumber(string number)
        {
            return _dbContext.Products
                .Where(product => product.Status != ItemStatus.Deleted && product.Number.Contains(number))
                .ToList();
        }

        public int GetTotalStockQty(int id)
        {
            return _dbContext.Products
                .Include(product => product.Stock)
                .Where(productStock => productStock.Stock.Id == id)
                .Sum(product => product.Quantity ?? 0);
        }

        public void Update(Product product)
        {
            _dbContext.Update(product);
        }
    }
}
