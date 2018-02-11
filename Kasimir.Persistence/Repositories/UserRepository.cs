using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(User user)
        {
            _dbContext.Add(user);
        }

        public void AddRange(IEnumerable<User> users)
        {
            _dbContext.AddRange(users);
        }

        public void Delete(User user)
        {
            user.Status = ItemStatus.Deleted;
            Update(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users
                .Where(user => user.Status != ItemStatus.Deleted)
                .ToList();
        }

        public IEnumerable<User> GetByFirstName(string firstName)
        {
            return _dbContext.Users
                .Where(user => user.FirstName.Contains(firstName))
                .ToList();
        }

        public IEnumerable<User> GetByFullName(string firstName, string lastName)
        {
            return _dbContext.Users
                .Where(user => user.FirstName.Contains(firstName) && user.LastName.Contains(lastName))
                .ToList();
        }

        public User GetById(int id)
        {
            return _dbContext.Users
                .Where(user => user.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<User> GetByLastName(string lastName)
        {
            return _dbContext.Users
                .Where(user => user.LastName.Contains(lastName))
                .ToList();
        }

        public User GetByLogin(string login)
        {
            return _dbContext.Users
                .Where(user => user.Login == login)
                .SingleOrDefault();
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
