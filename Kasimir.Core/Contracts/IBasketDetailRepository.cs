using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface IBasketDetailRepository
    {
        void Add(BasketDetail basketDetail);
        void AddRange(IEnumerable<BasketDetail> basketDetails);
        void Update(BasketDetail basketDetail);
        void UpdateRange(IEnumerable<BasketDetail> basketDetails);
        void Delete(BasketDetail basketDetail);
        IEnumerable<BasketDetail> GetAll();
        BasketDetail GetById(int id);
    }
}
