using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Persistence.Repositories
{
    public class CashDrawerRepository : ICashDrawerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CashDrawerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CashDrawer>> GetAll()
        {
            return await _dbContext.CashDrawers.ToListAsync();
        }

        public async Task<CashDrawer> GetById(int id)
        {
            return await _dbContext.CashDrawers.FindAsync(id);
        }

        public void Update(CashDrawer cashDrawer)
        {
            _dbContext.Update(cashDrawer);
        }
    }
}
