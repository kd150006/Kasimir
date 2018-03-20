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
    [Route("api/basketheaders")]
    public class BasketHeadersController : Controller
    {
        private readonly IUnitOfWork _uow;
        public BasketHeadersController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/Baskets
        [HttpGet]
        public IEnumerable<BasketHeader> Get()
        {
            var baskets = _uow.BasketHeaderRepository.GetAll();
            return (baskets);
        }

        // GET: api/Baskets/5
        [HttpGet("id/{id}")]
        public BasketHeader Get(int id)
        {
            var basket = _uow.BasketHeaderRepository
                                .GetById(id);
            return (basket);
        }
        // GET: api/basketheaders/search/
        [HttpGet("search/{term}")]
        public IEnumerable<BasketHeader> GetBySearchTerm(string term)
        {
            var results = _uow.BasketHeaderRepository.GetBySearchTerm(term);
            return (results);
        }

        // POST: api/Baskets
        //[HttpPost]
        //public void Post([FromBody]BasketHeader basketHeader)
        //{
        //    _uow.BasketHeaderRepository.Add(basketHeader);
        //    _uow.Save();
        //    //int newId = _uow.BasketHeaderRepository.GetLastInsertedBasketHeaderId();
        //    //return newId;

        //}

        // POST: api/Baskets
        [HttpPost]
        public void Post([FromBody]BasketHeader basketHeader)
        {
            _uow.BasketHeaderRepository.Add(basketHeader);
            _uow.Save();
        }

        // PUT: api/Baskets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]BasketHeader basketHeader)
        {            
            _uow.BasketHeaderRepository.Update(basketHeader);
            _uow.Save();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var basket = _uow.BasketHeaderRepository.GetById(id);
            _uow.BasketHeaderRepository.Delete(basket);
        }

        //C
    }
}
