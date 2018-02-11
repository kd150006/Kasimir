using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Persistence.Repositories
{
    public class MeansOfPaymentRepository : IMeansOfPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MeansOfPaymentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(MeansOfPayment meansOfPayment)
        {
            _dbContext.Add(meansOfPayment);
        }

        public void AddRange(IEnumerable<MeansOfPayment> meansOfPayment)
        {
            _dbContext.AddRange(meansOfPayment);
        }

        public void Delete(MeansOfPayment meansOfPayment)
        {
            meansOfPayment.Status = ItemStatus.Deleted;
            Update(meansOfPayment);
        }

        public MeansOfPayment GetById(int id)
        {
            return _dbContext.MeansOfPayments
                .Where(meansOfPayment => meansOfPayment.Id == id)
                .Single();
        }

        public MeansOfPayment GetByName(string name)
        {
            return _dbContext.MeansOfPayments
                .Where(meansOfPayment => meansOfPayment.Name == name)
                .Single();
        }

        public void Update(MeansOfPayment meansOfPayment)
        {
            _dbContext.Update(meansOfPayment);
        }
    }
}
