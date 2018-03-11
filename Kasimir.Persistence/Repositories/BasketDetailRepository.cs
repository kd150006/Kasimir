using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Persistence.Repositories
{
    public class BasketDetailRepository : IBasketDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BasketDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(BasketDetail basketDetail)
        {
            _dbContext.BasketDetails.Add(basketDetail);
        }

        public void AddRange(IEnumerable<BasketDetail> basketDetails)
        {
            _dbContext.BasketDetails.AddRange(basketDetails);
        }

        public void Delete(BasketDetail basketDetail)
        {
            _dbContext.Remove(basketDetail);
        }

        public IEnumerable<BasketDetail> GetAll()
        {
            return _dbContext.BasketDetails.ToList();
        }

        public BasketDetail GetById(int id)
        {
            return _dbContext.BasketDetails.Find(id);
        }

        public void Update(BasketDetail basketDetail)
        {
            _dbContext.Update(basketDetail);
        }

        public void UpdateRange(IEnumerable<BasketDetail> basketDetails)
        {
            _dbContext.UpdateRange(basketDetails);
        }
    }
}
