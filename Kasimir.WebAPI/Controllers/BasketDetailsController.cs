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
    [Route("api/BasketDetails")]
    public class BasketDetailsController : Controller
    {
        private readonly IUnitOfWork _uow;
        public BasketDetailsController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/BasketDetails
        [HttpGet]
        public IEnumerable<BasketDetail> Get()
        {
            return _uow.BasketDetailRepository.GetAllWithProducts();
        }

        // GET: api/BasketDetails/5
        [HttpGet("id/{id}")]
        public IEnumerable<BasketDetail> Get(int id)
        {
            var basketDtls = _uow.BasketDetailRepository.GetByHeaderIdWithProducts(id);
            return (basketDtls);
        }

        // GET: apit/baskets/search/
        [HttpGet("search/{term}")]
        public IEnumerable<Product> GetBySearchTerm(string term)
        {
            var products = _uow.ProductRepository.GetBySearchTerm(term);
            return (products);
        }


        // POST: api/BasketDetails
        [HttpPost]
        public void Post([FromBody]BasketDetail basketDetail)
        {
            _uow.BasketDetailRepository.Add(basketDetail);
            _uow.Save();
        }
        
        // PUT: api/BasketDetails/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]BasketDetail basketDetail)
        {
            _uow.BasketDetailRepository.Update(basketDetail);
            _uow.Save();
        }
        
        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var basketToDelete = _uow.BasketDetailRepository.GetById(id);
        //    _uow.BasketDetailRepository.Delete(basketToDelete);
        //}
    }
}
