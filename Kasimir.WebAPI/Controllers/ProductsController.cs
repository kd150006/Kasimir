using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Kasimir.Core.Contracts;
using Kasimir.Core.DataTransferObjects;
using Kasimir.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kasimir.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _uow;        
        public ProductsController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET products/
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _uow.ProductRepository.GetAll();
            return (products);
        }

        // GET products/id/7
        [HttpGet("id/{id}")]
        public Product GetById(int id)
        {
            var product = _uow.ProductRepository.GetById(id);
            return (product);
        }
        // GET products/name/Goo
        [HttpGet("name/{name}")]
        public IEnumerable<Product> GetByName(string name)
        {
            var products = _uow.ProductRepository.GetByName(name);
            return (products);
        }
        // GET products/number/nok TO-DO
        [HttpGet("number/{number})")]
        public IEnumerable<Product> GetByNumber(string number)
        {
            var products = _uow.ProductRepository.GetByNumber(number);
            return (products);
        }

        // POST products
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            _uow.ProductRepository.Add(product);
            _uow.Save();
        }

        // PUT products/7
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product)
        {            
            _uow.ProductRepository.Update(product);
            _uow.Save();
        }

        // DELETE products/7
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var productToDelete = _uow.ProductRepository.GetById(id);
            _uow.ProductRepository.Delete(productToDelete);
            _uow.Save();
        }

    }
}
