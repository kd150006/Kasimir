using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetById(int id);
        IEnumerable<Product> GetBySerialNumber(string serialnumber);
        IEnumerable<Product> GetByStatus(string status);        
        int GetQuantityById(int id);
        int GetQuantityBySerialNumber(string serialnumber);
        void Add(Product product);
        void AddRange(IEnumerable<Product> products);
        void Update(Product product);
        void UpdateRange(IEnumerable<Product> products);
        void Delete(Product product);
        IEnumerable<Product> GetAllWithDetails();
        Product GetByIdWithDetails(int id);
        int GetQuantityByStock(int stockId);
        int GetQuantityAllStocks(int stockId);
        int GetQuantityByProduct(int productId);
        int GetQuantityByProductAndStockId(int productId, int stockId);
    }
}
