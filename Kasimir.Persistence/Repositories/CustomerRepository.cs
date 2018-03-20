using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
        }

        public async Task AddRange(IEnumerable<Customer> customers)
        {
            await _dbContext.Customers.AddRangeAsync(customers);
        }

        public void Delete(Customer customer)
        {
            customer.Status = ItemStatus.Deleted;
            Update(customer);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _dbContext.Customers
                .Where(customer => customer.Status != "D").ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetByFullname(string firstname, string lastname)
        {
            return await _dbContext.Customers.Where(customer => customer.FirstName + customer.LastName == firstname + lastname).ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Customers.Where(customer => customer.Status != "D").Where(customer => customer.Id == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> GetByStatus(string status)
        {
            return await _dbContext.Customers.Where(customer => customer.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetNyNumber(string number)
        {
            return await _dbContext.Customers.Where(customer => customer.Number == number).ToListAsync();
        }

        public void Update(Customer customer)
        {
            _dbContext.Customers.Update(customer);
        }
    }
}
