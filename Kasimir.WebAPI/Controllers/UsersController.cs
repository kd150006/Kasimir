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
        public async Task<IActionResult> Get()
        {
            var usersOverview = await _uow.UserRepository.GetAll();
            return Ok(usersOverview);
        }

        // GET: api/Users/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _uow.UserRepository.GetById(id);
            return Ok(user);
        }
        
        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            _uow.UserRepository.Add(user);
            await _uow.Save();
            return Ok(user);
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]User user)
        {            
            _uow.UserRepository.Update(user);
            await _uow.Save();
            return Ok(user);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _uow.UserRepository.GetById(id);
            _uow.UserRepository.Delete(user);
            await _uow.Save();
            return Ok(user);
        }
    }
}
