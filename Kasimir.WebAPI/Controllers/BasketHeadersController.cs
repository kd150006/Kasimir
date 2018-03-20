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
        public async Task<IActionResult> Get()
        {
            var baskets = await _uow.BasketHeaderRepository.GetAll();
            return Ok(baskets);
        }

        // GET: api/Baskets/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var basket = await _uow.BasketHeaderRepository
                                .GetById(id);
            return Ok(basket);
        }
        // GET: api/basketheaders/search/
        [HttpGet("search/{term}")]
        public async Task<IActionResult> GetBySearchTerm(string term)
        {
            var results = await _uow.BasketHeaderRepository.GetBySearchTerm(term);
            return Ok(results);
        }
        //GET: api/basketheaders/latest/
        [HttpGet("latest/")]
        public async Task<IActionResult> GetLatest()
        {
            var result = await _uow.BasketHeaderRepository.GetLatestBasketHeader();
            return Ok(result);
        }

        // POST: api/Baskets
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BasketHeader basketHeader)
        {
            await _uow.BasketHeaderRepository.Add(basketHeader);
            await _uow.Save();
            return Ok(basketHeader);
        }

        // PUT: api/Baskets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]BasketHeader basketHeader)
        {            
            _uow.BasketHeaderRepository.Update(basketHeader);
            await _uow.Save();
            return Ok(basketHeader);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var basket = await _uow.BasketHeaderRepository.GetById(id);
            _uow.BasketHeaderRepository.Delete(basket);
            return Ok(basket);
        }
    }
}
