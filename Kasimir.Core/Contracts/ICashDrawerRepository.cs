using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface ICashDrawerRepository
    {
        IEnumerable<CashDrawer> GetAll();
        CashDrawer GetById(int id);
        void Update(CashDrawer cashDrawer);
    }
}
