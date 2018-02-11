using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface IJournalRepository
    {
        IEnumerable<Journal> GetAll();
        IEnumerable<Journal> GetByTransactionType(bool isPurchase, bool isCancellation, bool isExchange, bool isReturn);
        IEnumerable<Journal> GetByDate(DateTime dateOfTransaction);
        IEnumerable<Journal> GetByDateRange(DateTime filterStartDate, DateTime? filterEndDate);
        Journal GetById(int id);
        IEnumerable<Journal> GetByDateRangeAndTransactionType(DateTime filterStartDate, DateTime? filterEndDate, bool isPurchase, bool isCancellation, bool isExchange, bool isReturn);
        void Add(Journal journal);
        void AddRange(IEnumerable<Journal> journal);
        void Update(Journal journal);
        void Delete(Journal journal);
    }
}
