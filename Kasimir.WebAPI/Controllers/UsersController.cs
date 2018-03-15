using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kasimir.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _uow;
        public UsersController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var usersOverview = _uow.UserRepository.GetAll().OrderBy(user => user.LastName);
            return (usersOverview);
        }

        // GET: api/Users/5
        [HttpGet("id/{id}")]
        public User Get(int id)
        {
            var user = _uow.UserRepository.GetById(id);
            return (user);
        }
        
        // POST: api/Users
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _uow.UserRepository.Add(user);
            _uow.Save();
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {            
            _uow.UserRepository.Update(user);
            _uow.Save();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _uow.UserRepository.GetById(id);
            _uow.UserRepository.Delete(user);
            _uow.Save();
        }
    }
}
