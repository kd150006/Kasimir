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
        public async Task<IActionResult> Get()
        {
            var basketDetails = await _uow.BasketDetailRepository.GetAllWithProducts();
            return Ok(basketDetails);
        }

        // GET: api/BasketDetails/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var basketDtls = await _uow.BasketDetailRepository.GetByHeaderIdWithProducts(id);
            return Ok(basketDtls);
        }

        // GET: apit/baskets/search/
        [HttpGet("search/{term}")]
        public async Task<IActionResult> GetBySearchTerm(string term)
        {
            var products = await _uow.ProductRepository.GetBySearchTerm(term);
            return Ok(products);
        }


        // POST: api/BasketDetails
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BasketDetail basketDetail)
        {
            await _uow.BasketDetailRepository.Add(basketDetail);
            await _uow.Save();
            return Ok(basketDetail);
        }
        
        // PUT: api/BasketDetails/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]BasketDetail basketDetail)
        {
            _uow.BasketDetailRepository.Update(basketDetail);
            _uow.Save();            
        }

    }
}
