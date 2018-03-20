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
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _uow;
        public CustomersController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/Customers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customerOverview = await _uow.CustomerRepository.GetAll();
            return Ok(customerOverview);
        }

        // GET: api/Customers/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _uow.CustomerRepository.GetById(id);
            return Ok(customer);
        }
        
        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            await _uow.CustomerRepository.Add(customer);
            await _uow.Save();
            return Ok(customer);
        }
        
        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Customer customer)
        {            
            _uow.CustomerRepository.Update(customer);
            await _uow.Save();
            return Ok(customer);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _uow.CustomerRepository.GetById(id);
            _uow.CustomerRepository.Delete(customer);
            await _uow.Save();
            return Ok(customer);
        }
    }
}
