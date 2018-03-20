using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface IProductRepository
    {
        void AddRange(List<Product> products);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetBySearchTerm(string searchTerm);        
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllByStockId(int id);
        int GetTotalStockQty(int id);
    }
}
