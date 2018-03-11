using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
   public interface IBasketHeaderRepository
    {
        IEnumerable<BasketHeader> GetAll();
        BasketHeader GetById(int id);
        BasketHeader GetByIdWithDetails(int id);
        int GetLastInsertedBasketHeaderId();
        void Add(BasketHeader basketHeader);
        void AddRange(IEnumerable<BasketHeader> basketHeaders);
        void Update(BasketHeader basketHeader);
        void UpdateRange(BasketHeader basketHeaders);
        void Delete(BasketHeader basketHeader);

        void AddToBasket(Product product);
        void RemoveFromBasket(Product product);
        void ClearBasket();
    }
}
