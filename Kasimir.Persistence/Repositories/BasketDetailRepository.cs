using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Persistence.Repositories
{
    public class BasketDetailRepository : IBasketDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BasketDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(BasketDetail basketDetail)
        {
           await _dbContext.BasketDetails.AddAsync(basketDetail);
        }

        public async Task AddRange(IEnumerable<BasketDetail> basketDetails)
        {
            await _dbContext.BasketDetails.AddRangeAsync(basketDetails);
        }

        public void Delete(BasketDetail basketDetail)
        {
           _dbContext.Remove(basketDetail);
        }

        public async Task<IEnumerable<BasketDetail>> GetAllWithProducts()
        {
            return await _dbContext.BasketDetails.Include(basketDtls => basketDtls.Product).ToListAsync();
        }

        public async Task<IEnumerable<BasketDetail>> GetByHeaderIdWithProducts(int id)
        {
            return await _dbContext.BasketDetails.Include(basketDtls => basketDtls.Product).Where(basketDtl => basketDtl.BasketHeaderId == id).ToListAsync();
        }

        public async Task<IEnumerable<BasketDetail>> GetBySearchTerm(string term)
        {
            return await _dbContext.BasketDetails
                .Include(basketDtls => basketDtls.Product)
                .Where(basketDtlsWithProduct =>
                basketDtlsWithProduct.Product.Name.Contains(term) ||
                basketDtlsWithProduct.BasketHeader.Id.ToString().Contains(term) ||
                basketDtlsWithProduct.BasketHeader.BasketDate.ToString().Contains(term)
                )
                .ToListAsync();
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
