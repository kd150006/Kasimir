using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Core.Contracts
{
    public interface ICashDrawerRepository
    {
        Task<IEnumerable<CashDrawer>> GetAll();
        Task<CashDrawer> GetById(int id);
        void Update(CashDrawer cashDrawer);
    }
}
