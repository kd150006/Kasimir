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
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _uow;
        public ProductsController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _uow.ProductRepository.GetAll();
            return (products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _uow.ProductRepository.GetByIdWithDetails(id);
            return (product);
        }

        //GET: api/Products/GetQuantity/7
        [HttpGet("{id}"), Route("GetQuantity")]
        public int GetQuantity(int id)
        {
            var productQuantity = _uow.ProductRepository.GetQuantityByProduct(id);
            return (productQuantity);
        }
        
        // POST: api/Products
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            _uow.ProductRepository.Add(product);
            _uow.Save();
        }
        
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product)
        {
            var productToUpdate = _uow.ProductRepository.GetByIdWithDetails(id);
            _uow.ProductRepository.Update(productToUpdate);
            _uow.Save();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var productToDelete = _uow.ProductRepository.GetById(id).SingleOrDefault();
            _uow.ProductRepository.Delete(productToDelete);
        }
    }
}
