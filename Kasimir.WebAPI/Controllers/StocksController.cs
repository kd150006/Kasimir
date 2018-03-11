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
        public IEnumerable<Stock> Get()
        {
            var stocksOverview = _uow.StockRepository.GetAll();
            return (stocksOverview);
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public Stock Get(int id)
        {
            //var stock = _uow.StockRepository.GetById(id).SingleOrDefault();
            var stock = _uow.StockRepository.GetStockByIdWithProducts(id);
            return (stock);
        }

        //GET: api/Stocks/5
        [HttpGet, Route("GetQuantity")]
        public int GetQuantity()
        {
            var quantity = _uow.StockRepository.GetQuantityOfAllStocks();
            return (quantity);
        }
        // POST: api/Stocks
        [HttpPost]
        public void Post([FromBody]Stock stock)
        {
            _uow.StockRepository.Add(stock);
            _uow.Save();
        }
        
        // PUT: api/Stocks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Stock stock)
        {            
            _uow.StockRepository.Update(stock);
            _uow.Save();
        }
        
        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var stock = _uow.StockRepository.GetById(id);
            _uow.StockRepository.Delete(stock);
            _uow.Save();
        }
    }
}
