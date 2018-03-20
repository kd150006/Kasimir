using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<BasketDetail> GetAllWithProducts()
        {
            return _dbContext.BasketDetails.Include(basketDtls => basketDtls.Product);
        }

        public IEnumerable<BasketDetail> GetByHeaderIdWithProducts(int id)
        {
            return _dbContext.BasketDetails.Include(basketDtls => basketDtls.Product).Where(basketDtl => basketDtl.BasketHeaderId == id);
        }

        public IEnumerable<BasketDetail> GetBySearchTerm(string term)
        {
            return _dbContext.BasketDetails
                .Include(basketDtls => basketDtls.Product)
                .Where(basketDtlsWithProduct =>
                basketDtlsWithProduct.Product.Name.Contains(term) ||
                basketDtlsWithProduct.BasketHeader.Id.ToString().Contains(term) ||
                basketDtlsWithProduct.BasketHeader.BasketDate.ToString().Contains(term)
                );
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
