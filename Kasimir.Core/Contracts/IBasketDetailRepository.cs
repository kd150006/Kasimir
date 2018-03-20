using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Core.Contracts
{
    public interface IBasketDetailRepository
    {
        Task Add(BasketDetail basketDetail);
        Task AddRange(IEnumerable<BasketDetail> basketDetails);
        void Update(BasketDetail basketDetail);
        void UpdateRange(IEnumerable<BasketDetail> basketDetails);
        void Delete(BasketDetail basketDetail);
        Task<IEnumerable<BasketDetail>> GetAllWithProducts();
        Task<IEnumerable<BasketDetail>> GetByHeaderIdWithProducts(int id);
        Task<IEnumerable<BasketDetail>> GetBySearchTerm(string term);
        
    }
}
