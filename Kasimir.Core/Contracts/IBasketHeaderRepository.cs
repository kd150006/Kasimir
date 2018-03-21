using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Core.Contracts
{
   public interface IBasketHeaderRepository
    {
        Task<IEnumerable<BasketHeader>> GetAll();
        Task<IEnumerable<BasketHeader>> GetAllWithDetailsAndProducts();
        Task<BasketHeader> GetById(int id);
        Task<IEnumerable<BasketHeader>> GetAllSalesTrx(string trxType);
        Task<BasketHeader> GetByIdWithDetails(int id);
        Task<BasketHeader> GetLatestBasketHeader();        
        Task Add(BasketHeader basketHeader);
        Task AddRange(IEnumerable<BasketHeader> basketHeaders);
        void Update(BasketHeader basketHeader);
        void UpdateRange(BasketHeader basketHeaders);
        void Delete(BasketHeader basketHeader);
        Task<IEnumerable<BasketHeader>> GetBySearchTerm(string term);
    }
}
