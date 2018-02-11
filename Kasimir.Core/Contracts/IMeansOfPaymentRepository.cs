using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
   public  interface IMeansOfPaymentRepository
    {
        void Add(MeansOfPayment meansOfPayment);
        void AddRange(IEnumerable<MeansOfPayment> meansOfPayment);
        void Update(MeansOfPayment meansOfPayment);
        void Delete(MeansOfPayment meansOfPayment);
        MeansOfPayment GetById(int id);
        MeansOfPayment GetByName(string name);

    }
}
