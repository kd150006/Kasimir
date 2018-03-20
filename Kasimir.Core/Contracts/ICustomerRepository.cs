using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Core.Contracts
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer);
        Task AddRange(IEnumerable<Customer> customers);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<IEnumerable<Customer>> GetNyNumber(string number);
        Task<IEnumerable<Customer>> GetByStatus(string status);
        Task<IEnumerable<Customer>> GetByFullname(string firstname, string lastname);
    }
}
