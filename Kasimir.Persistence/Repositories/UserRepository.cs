using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasimir.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(User user)
        {
            await _dbContext.AddAsync(user);
        }

        public async Task AddRange(IEnumerable<User> users)
        {
            await _dbContext.AddRangeAsync(users);
        }

        public void Delete(User user)
        {
            user.Status = ItemStatus.Deleted;
            Update(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users
                .Where(user => user.Status != ItemStatus.Deleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByFirstName(string firstName)
        {
            return await _dbContext.Users
                .Where(user => user.FirstName.Contains(firstName))
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByFullName(string firstName, string lastName)
        {
            return await _dbContext.Users
                .Where(user => user.FirstName.Contains(firstName) && user.LastName.Contains(lastName))
                .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users
                .Where(user => user.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetByLastName(string lastName)
        {
            return await _dbContext.Users
                .Where(user => user.LastName.Contains(lastName))
                .ToListAsync(); ;
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _dbContext.Users
                .Where(user => user.Login == login)
                .SingleOrDefaultAsync();
        }

        public void Update(User user)
        {
            _dbContext.Update(user);
        }

        public void UpdateRange(IEnumerable<User> users)
        {
            _dbContext.UpdateRange(users);
        }
    }    
}
