using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kasimir.Core.Contracts;
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
            var products = _uow.ProductRepository.GetAll().OrderBy(product => product.Name);
            return (products);
        }
        [HttpGet("stock/{id}")]
        public IEnumerable<Product> GetAllByStockId(int id)
        {
            var products = _uow.ProductRepository.GetAllByStockId(id);
            return products;
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
        
        [HttpGet("number/{number}")]
        public IEnumerable<Product> GetByNumber(string number)
        {
            var products = _uow.ProductRepository.GetByNumber(number);
            return (products);
        }
        // GET total quantiy of all products on a given stock
        [HttpGet("qty/{id}")]
        public int GetTotalQtyInStock(int id)
        {
            var totalQty = _uow.ProductRepository.GetTotalStockQty(id);
            return (totalQty);
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
