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

        public void AddRange(IEnumerable<Product> products)
        {
            _dbContext.AddRange(products);
        }

        public void Delete(Product product)
        {
            product.Status = ItemStatus.Deleted;
            Update(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext
                .Products                
                .ToList();
        }

        public IEnumerable<Product> GetAllWithDetails()
        {
            return _dbContext.Products
                .Include(product => product.ProductType)                
                .ToList();
        }

        public IEnumerable<Product> GetById(int id)
        {
            return _dbContext
                .Products                
                .Where(product => product.Id == id);
        }

        public Product GetByIdWithDetails(int id)
        {
            return _dbContext.Products
                .Include(product => product.ProductType)
                .Where(productWithDetails => productWithDetails.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<Product> GetBySerialNumber(string serialnumber)
        {
            return _dbContext
                .Products               
                .Include(product => product.ProductType)
                .Include(product => product.Stock)
                .Where(product => product.SerialNumber == serialnumber);
        }

        public IEnumerable<Product> GetByStatus(string status)
        {
            return _dbContext
                .Products
                .Where(product => product.Status == status);
        }

        public int GetQuantityAllStocks(int stockId)
        {
            return _dbContext.Products
                .Include(product => product.StockId.Equals(stockId))
                .Where(productsByStock => productsByStock.Status != ItemStatus.Deleted)
                .Count();
        }

        public int GetQuantityById(int id)
        {
            return _dbContext
                .Products
                .Where(product => product.Id == id)
                .Count();
        }

        public int GetQuantityByProduct(int productId)
        {
            return _dbContext.Products
                .Where(product => productId.Equals(productId))
                .Include(product => product.Stock)
                .Count();
        }

        public int GetQuantityByProductAndStockId(int productId, int stockId)
        {
            return _dbContext.Products
                .Where(product => product.Id.Equals(productId))
                .Include(product => product.StockId.Equals(stockId))
                .Count();
        }

        public int GetQuantityBySerialNumber(string serialnumber)
        {
            return _dbContext
                .Products
                .Include(product => product.ProductType)
                .Where(product => product.SerialNumber == serialnumber)
                .Count();
        }

        public int GetQuantityByStock(int stockId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            _dbContext.Update(product);
        }

        public void UpdateRange(IEnumerable<Product> products)
        {
            _dbContext.UpdateRange(products);
        }
    }
}
