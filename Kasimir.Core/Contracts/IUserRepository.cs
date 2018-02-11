using Kasimir.Core.Entities;
using System.Collections.Generic;

namespace Kasimir.Core.Contracts
{
    public interface IUserRepository
    {
        void Add(User user);
        void AddRange(IEnumerable<User> users);
        void Update(User user);
        void UpdateRange(IEnumerable<User> users);
        void Delete(User user);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByLogin(string login);
        IEnumerable<User> GetByFirstName(string firstName);
        IEnumerable<User> GetByLastName(string lastName);
        IEnumerable<User> GetByFullName(string firstName, string lastName);
    }
}
