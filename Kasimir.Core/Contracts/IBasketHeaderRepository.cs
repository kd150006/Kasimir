using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
   public interface IBasketHeaderRepository
    {
        IEnumerable<BasketHeader> GetAll();
        IEnumerable<BasketHeader> GetAllWithDetailsAndProducts();
        BasketHeader GetById(int id);
        BasketHeader GetByIdWithDetails(int id);
        int GetLastInsertedBasketHeaderId();
        int GetMaxBasketNumber();
        void Add(BasketHeader basketHeader);
        void AddRange(IEnumerable<BasketHeader> basketHeaders);
        void Update(BasketHeader basketHeader);
        void UpdateRange(BasketHeader basketHeaders);
        void Delete(BasketHeader basketHeader);
        IEnumerable<BasketHeader> GetBySearchTerm(string term);
    }
}
