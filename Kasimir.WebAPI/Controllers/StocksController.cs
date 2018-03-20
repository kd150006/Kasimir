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
    [Route("api/Stocks")]
    public class StocksController : Controller
    {
        private readonly IUnitOfWork _uow;
        public StocksController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/Stocks
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stocksOverview = await _uow.StockRepository.GetAll();
            return Ok(stocksOverview);
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //var stock = _uow.StockRepository.GetById(id).SingleOrDefault();
            var stock = await _uow.StockRepository.GetById(id);
            return Ok(stock);
        }

        //GET: api/Stocks/5
        [HttpGet, Route("GetQuantity")]
        public async Task<IActionResult> GetQuantity()
        {
            var quantity = await _uow.StockRepository.GetQuantityOfAllStocks();
            return Ok(quantity);
        }
        // POST: api/Stocks
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Stock stock)
        {
            await _uow.StockRepository.Add(stock);
            await _uow.Save();
            return Ok(stock);
        }
        
        // PUT: api/Stocks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Stock stock)
        {            
            _uow.StockRepository.Update(stock);
            await _uow.Save();
            return Ok();
        }
        
        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stock = await _uow.StockRepository.GetById(id);
            _uow.StockRepository.Delete(stock);
            await _uow.Save();
            return Ok();
        }
    }
}
