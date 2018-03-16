using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void AddRange(IEnumerable<Customer> customers);
        void Update(Customer customer);
        void Delete(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        IEnumerable<Customer> GetNyNumber(string number);
        IEnumerable<Customer> GetByStatus(string status);
        IEnumerable<Customer> GetByFullname(string firstname, string lastname);
    }
}
