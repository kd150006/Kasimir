using Kasimir.Core;
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
    public class BasketHeaderRepository : IBasketHeaderRepository
    {
        private readonly ApplicationDbContext _dbContext;        
        public BasketHeaderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;            
        }

        public async Task Add(BasketHeader basketHeader)
        {
            await _dbContext.AddAsync(basketHeader);
        }

        public async Task AddRange(IEnumerable<BasketHeader> basketHeaders)
        {
            await _dbContext.AddRangeAsync(basketHeaders);
        }

        public void Delete(BasketHeader basketHeader)
        {            
            _dbContext.Remove(basketHeader);
        }

        public async Task<IEnumerable<BasketHeader>> GetAll()
        {
            return await _dbContext.BasketHeaders.ToListAsync();
        }

        public async Task<IEnumerable<BasketHeader>> GetAllSalesTrx(string trxType)
        {
            var result = await _dbContext.BasketHeaders
                    .Where(basketHeader => basketHeader.TransactionType.ToLower() == trxType.ToLower() &&
                    basketHeader.Returned == false)
                    .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<BasketHeader>> GetAllWithDetailsAndProducts()
        {
            return await _dbContext.BasketHeaders
                .Include(basketHeader => basketHeader.BasketDetails)
                    .ThenInclude(basketDetails => basketDetails.Product).ToListAsync();
        }

        public async Task<BasketHeader> GetById(int id)
        {
            return await _dbContext.BasketHeaders.FindAsync(id);
        }

        public async Task<BasketHeader> GetByIdWithDetails(int id)
        {
            return await _dbContext.BasketHeaders
                .Include(basketHeader => basketHeader.BasketDetails)
                .Where(basketHeader => basketHeader.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<BasketHeader>> GetBySearchTerm(string term)
        {
            var results = await _dbContext.BasketHeaders
                .Include(basketHdr => basketHdr.BasketDetails)
                .Where(basketHdrWithDtlsAndProducts =>
                    basketHdrWithDtlsAndProducts.BasketDate.ToString().Contains(term) ||
                    basketHdrWithDtlsAndProducts.Id.ToString().Contains(term))
                .ToListAsync();
                                            
            return (results);
        }

        public async Task<BasketHeader> GetLatestBasketHeader()
        {
            return await _dbContext.BasketHeaders
                    .OrderByDescending(basketHeader => basketHeader.Id)
                    .FirstOrDefaultAsync();
        }

        public void Update (BasketHeader basketHeader)
        {
            _dbContext.Update(basketHeader);
        }

        public void UpdateRange(BasketHeader basketHeaders)
        {
            _dbContext.UpdateRange(basketHeaders);
        }
    }
}
