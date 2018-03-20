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
    public class BasketHeaderRepository : IBasketHeaderRepository
    {
        private readonly ApplicationDbContext _dbContext;        
        public BasketHeaderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public void Add(BasketHeader basketHeader)
        {
            _dbContext.Add(basketHeader);
        }

        public void AddRange(IEnumerable<BasketHeader> basketHeaders)
        {
            _dbContext.AddRange(basketHeaders);
        }

        public void Delete(BasketHeader basketHeader)
        {            
            _dbContext.Remove(basketHeader);
        }

        public IEnumerable<BasketHeader> GetAll()
        {
            return _dbContext.BasketHeaders;
        }

        public IEnumerable<BasketHeader> GetAllWithDetailsAndProducts()
        {
            return _dbContext.BasketHeaders
                .Include(basketHeader => basketHeader.BasketDetails)
                    .ThenInclude(basketDetails => basketDetails.Product);
        }

        public BasketHeader GetById(int id)
        {
            return _dbContext.BasketHeaders.Find(id);
        }

        public BasketHeader GetByIdWithDetails(int id)
        {
            return _dbContext.BasketHeaders
                .Include(basketHeader => basketHeader.BasketDetails)
                .Where(basketHeader => basketHeader.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<BasketHeader> GetBySearchTerm(string term)
        {
            var results = _dbContext.BasketHeaders
                .Include(basketHdr => basketHdr.BasketDetails)                    
                .Where(basketHdrWithDtlsAndProducts => 
                    basketHdrWithDtlsAndProducts.BasketDate.ToString().Contains(term) ||
                    basketHdrWithDtlsAndProducts.Id.ToString().Contains(term));
                                            
            return (results);
        }

        public int GetLastInsertedBasketHeaderId()
        {
            return _dbContext.BasketHeaders
                .OrderByDescending(basketHeader => basketHeader.Id)
                .Select(basketHeader => basketHeader.Id)
                .FirstOrDefault();
        }

        public int GetMaxBasketNumber()
        {
            throw new NotImplementedException();
            //return _dbContext.BasketHeaders.Select(basketHeader => basketHeader.BasketNumber).Max();
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
