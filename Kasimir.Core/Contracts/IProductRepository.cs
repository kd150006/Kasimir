using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Core.Contracts
{
    public interface IProductRepository
    {
        Task AddRange(List<Product> products);
        Task Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetBySearchTerm(string searchTerm);        
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetAllByStockId(int id);
        Task<int> GetTotalStockQty(int id);
    }
}
