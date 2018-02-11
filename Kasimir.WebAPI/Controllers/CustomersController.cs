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
        public IEnumerable<Customer> Get()
        {
            var customerOverview = _uow.CustomerRepository.GetAll();
            return (customerOverview);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var customer = _uow.CustomerRepository.GetById(id).SingleOrDefault();
            return (customer);
        }
        
        // POST: api/Customers
        [HttpPost]
        public void Post([FromBody]Customer customer)
        {
            _uow.CustomerRepository.Add(customer);
            _uow.Save();
        }
        
        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Customer customer)
        {
            var customerToUpdate = _uow.CustomerRepository.GetById(id).SingleOrDefault();
            _uow.CustomerRepository.Update(customerToUpdate);
            _uow.Save();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customer = _uow.CustomerRepository.GetById(id).SingleOrDefault();
            _uow.CustomerRepository.Delete(customer);
            _uow.Save();
        }
    }
}
