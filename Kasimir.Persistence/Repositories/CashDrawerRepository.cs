using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Persistence.Repositories
{
    public class CashDrawerRepository : ICashDrawerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CashDrawerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(CashDrawer cashDrawer)
        {
            _dbContext.Add(cashDrawer);
        }

        public void Delete(CashDrawer cashDrawer)
        {
            cashDrawer.Status = ItemStatus.Deleted;
            Update(cashDrawer);
        }

        public IEnumerable<CashDrawer> GetAll()
        {
            return _dbContext.CashDrawers
                .Where(cashDrawer => cashDrawer.Status != ItemStatus.Deleted)
                .ToList();
        }

        public CashDrawer GetById(int id)
        {
            return _dbContext
                .CashDrawers
                .Where(cd => cd.Id == id)
                .Single();
        }

        public CashDrawer GetByName(string name)
        {
            return _dbContext
                .CashDrawers
                .Where(cd => cd.Name == name)
                .Single();
        }

        public double GetCurrentAmount()
        {
            return _dbContext
                .CashDrawers
                .Select(cd => cd.Amount)
                .Single();
        }

        public void Update(CashDrawer cashDrawer)
        {
            _dbContext.Update(cashDrawer);
        }
    }
}
