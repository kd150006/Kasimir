using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
        }

        public void AddRange(IEnumerable<Customer> customers)
        {
            _dbContext.Customers.AddRange(customers);
        }

        public void Delete(Customer customer)
        {
            customer.Status = ItemStatus.Deleted;
            Update(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customers;
        }

        public IEnumerable<Customer> GetByFullname(string firstname, string lastname)
        {
            return _dbContext.Customers.Where(customer => customer.FirstName + customer.LastName == firstname + lastname);
        }

        public IEnumerable<Customer> GetById(int id)
        {
            return _dbContext.Customers.Where(customer => customer.Id == id);
        }

        public IEnumerable<Customer> GetByStatus(string status)
        {
            return _dbContext.Customers.Where(customer => customer.Status == status);
        }

        public IEnumerable<Customer> GetNyNumber(string number)
        {
            return _dbContext.Customers.Where(customer => customer.Number == number);
        }

        public void Update(Customer customer)
        {
            _dbContext.Customers.Update(customer);
        }
    }
}
