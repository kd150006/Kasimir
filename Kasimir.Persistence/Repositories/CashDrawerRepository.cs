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

        public IEnumerable<CashDrawer> GetAll()
        {
            return _dbContext.CashDrawers.ToList();
        }

        public CashDrawer GetById(int id)
        {
            return _dbContext.CashDrawers.Find(id);
        }

        public void Update(CashDrawer cashDrawer)
        {
            _dbContext.Update(cashDrawer);
        }
    }
}
