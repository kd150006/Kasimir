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
    public class BasketHeaderRepository : IBasketRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private List<Product> basketList;
        public BasketHeaderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            basketList = new List<Product>();
        }

        public void Add(BasketHeader basketHeader)
        {
            _dbContext.Add(basketHeader);
        }

        public void AddRange(IEnumerable<BasketHeader> basketHeaders)
        {
            _dbContext.AddRange(basketHeaders);
        }

        public void AddToBasket(Product product)
        {
            basketList.Add(product);
        }

        public void ClearBasket()
        {
            basketList.Clear();
        }

        public void Delete(BasketHeader basketHeader)
        {            
            _dbContext.Remove(basketHeader);
        }

        public IEnumerable<BasketHeader> GetAll()
        {
            return _dbContext.BasketHeaders                
                .ToList();
        }

        public void RemoveFromBasket(Product product)
        {
            basketList.Remove(product);            
        }

        public void Update(BasketHeader basketHeader)
        {
            _dbContext.Update(basketHeader);
        }

        public void UpdateRange(BasketHeader basketHeaders)
        {
            _dbContext.UpdateRange(basketHeaders);
        }
    }
}
