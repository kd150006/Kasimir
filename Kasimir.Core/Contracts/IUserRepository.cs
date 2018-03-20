using Kasimir.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kasimir.Core.Contracts
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task AddRange(IEnumerable<User> users);
        void Update(User user);
        void UpdateRange(IEnumerable<User> users);
        void Delete(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByLogin(string login);
        Task<IEnumerable<User>> GetByFirstName(string firstName);
        Task<IEnumerable<User>> GetByLastName(string lastName);
        Task<IEnumerable<User>> GetByFullName(string firstName, string lastName);
    }
}
