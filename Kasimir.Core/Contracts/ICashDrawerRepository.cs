using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface ICashDrawerRepository
    {
        double GetCurrentAmount();
        CashDrawer GetById(int id);
        CashDrawer GetByName(string name);
        IEnumerable<CashDrawer> GetAll();
        void Delete(CashDrawer cashDrawer);
        void Update(CashDrawer cashDrawer);
        void Add(CashDrawer cashDrawer);
    }
}
