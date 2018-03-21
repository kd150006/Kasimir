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
        public async Task<IActionResult> Get()
        {
            var products = await _uow.ProductRepository.GetAll();                
            return Ok(products);
        }
        [HttpGet("stock/{id}")]
        public async Task<IActionResult> GetAllByStockId(int id)
        {
            var products = await _uow.ProductRepository.GetAllByStockId(id);
            return Ok(products);
        }

        // GET products/id/7
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _uow.ProductRepository.GetById(id);
            return Ok(product);
        }
        // GET products/name/Goo
        [HttpGet("search/{term}")]
        public async Task<IActionResult> GetBySearchTerm(string term)
        {
            var products = await _uow.ProductRepository.GetBySearchTerm(term);
            return Ok(products);
        }

        // GET total quantiy of all products on a given stock
        [HttpGet("qty/{id}")]
        public async Task<IActionResult> GetTotalQtyInStock(int id)
        {
            var totalQty = await _uow.ProductRepository.GetTotalStockQty(id);
            return Ok(totalQty);
        }

        // POST products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            await _uow.ProductRepository.Add(product);
            await _uow.Save();
            return Ok(product);
        }

        // PUT products/7
        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, [FromBody]Product product)
        {            
            _uow.ProductRepository.Update(product);
            await _uow.Save();
            return Ok();
        }

        // DELETE products/7
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productToDelete = await _uow.ProductRepository.GetById(id);
            _uow.ProductRepository.Delete(productToDelete);
            await _uow.Save();
            return Ok();
        }

    }
}
