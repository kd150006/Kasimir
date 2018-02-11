using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Kasimir.Persistence
{
    public class JournalRepository : IJournalRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public JournalRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Journal journal)
        {
            _dbContext.Add(journal);
        }

        public void AddRange(IEnumerable<Journal> journal)
        {
            _dbContext.AddRange(journal);
        }

        public void Delete(Journal journal)
        {
            _dbContext.Remove(journal);
        }

        public IEnumerable<Journal> GetAll()
        {
            return _dbContext
                .Journals
                .ToList();
        }

        public IEnumerable<Journal> GetByDate(DateTime dateOfTransaction)
        {
            return _dbContext
                .Journals
                .Where(journal => journal.DateOfTransaction == dateOfTransaction)
                .ToList();
        }

        public IEnumerable<Journal> GetByDateRange(DateTime filterStartDate, DateTime? filterEndDate)
        {
            if (filterEndDate == null)
            {
                filterEndDate = DateTime.Now;
            }

            return _dbContext
                .Journals
                .Where(journal => journal.DateOfTransaction >= filterStartDate && journal.DateOfTransaction <= filterEndDate)
                .OrderBy(filteredJournal => filteredJournal.DateOfTransaction)
                .ToList();
        }

        public IEnumerable<Journal> GetByDateRangeAndTransactionType(DateTime filterStartDate, DateTime? filterEndDate, bool isCancellation, bool isExchange, bool isPurchase, bool isReturn)
        {
            List<Journal> resultList = new List<Journal>();
            if (filterEndDate == null)
            {
                filterEndDate = DateTime.Now;
            }

            var journalsFilteredByDate =
                _dbContext
                .Journals
                .Where(journal => journal.DateOfTransaction >= filterStartDate && journal.DateOfTransaction <= filterEndDate)
                .OrderBy(filteredJournal => filteredJournal.DateOfTransaction);

            if (isCancellation)
            {
                var resultsToAdd = journalsFilteredByDate.Where(j => j.TransactionType == TransactionType.Cancellation);                        
                resultList.AddRange(resultsToAdd);
            }
            if (isExchange)
            {
                var resultsToAdd = journalsFilteredByDate.Where(j => j.TransactionType == TransactionType.Exchange);
                resultList.AddRange(resultsToAdd);
            }
            if (isPurchase)
            {
                var resultsToAdd = journalsFilteredByDate.Where(j => j.TransactionType == TransactionType.Purchase);
                resultList.AddRange(resultsToAdd);
            }
            if (isReturn)
            {
                var resultsToAdd = journalsFilteredByDate.Where(j => j.TransactionType == TransactionType.Return);
                resultList.AddRange(resultsToAdd);
            }

            return resultList;
        }

        public Journal GetById(int id)
        {
            return _dbContext
                .Journals
                .Where(journal => journal.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<Journal> GetByTransactionType(bool isCancellation, bool isExchange, bool isPurchase, bool isReturn)
        {            
            List<Journal> resultList = new List<Journal>();                        

            if (isCancellation)
            {
                var resultsToAdd = _dbContext
                                        .Journals
                                        .Where(journal => journal.TransactionType == TransactionType.Cancellation);
                resultList.AddRange(resultsToAdd);
            }
            if (isExchange)
            {
                var resultsToAdd = _dbContext
                                        .Journals
                                        .Where(journal => journal.TransactionType == TransactionType.Exchange);
                resultList.AddRange(resultsToAdd);
            }
            if (isPurchase)
            {
                var resultsToAdd = _dbContext
                                        .Journals
                                        .Where(journal => journal.TransactionType == TransactionType.Purchase);
                resultList.AddRange(resultsToAdd);
            }
            if (isReturn)
            {
                var resultsToAdd = _dbContext
                                        .Journals
                                        .Where(journal => journal.TransactionType == TransactionType.Return);
                resultList.AddRange(resultsToAdd);
            }
            return resultList;
        }

        public void Update(Journal journal)
        {
            _dbContext.Update(journal);
        }
    }
}

