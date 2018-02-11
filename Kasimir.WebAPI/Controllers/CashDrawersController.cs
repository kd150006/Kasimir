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
    [Route("api/CashDrawers")]
    public class CashDrawersController : Controller
    {
        private readonly IUnitOfWork _uow;
        public CashDrawersController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/CashDrawers
        [HttpGet]
        public IEnumerable<CashDrawer> Get()
        {
            var cashDrawerOverview = _uow.CashDrawerRepository.GetAll();
            return (cashDrawerOverview);
        }

        // GET: api/CashDrawers/5
        [HttpGet("{id}")]
        public CashDrawer Get(int id)
        {
            var cashDrawer = _uow.CashDrawerRepository.GetById(id);
            return (cashDrawer);
        }
        
        // POST: api/CashDrawers
        [HttpPost]
        public void Post([FromBody]CashDrawer cashDrawer)
        {
            _uow.CashDrawerRepository.Add(cashDrawer);
            _uow.Save();
        }
        
        // PUT: api/CashDrawers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CashDrawer cashDrawer)
        {
            var cashDrawerToUpdate = _uow.CashDrawerRepository.GetById(id);
            _uow.CashDrawerRepository.Update(cashDrawerToUpdate);
            _uow.Save();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cashDrawer = _uow.CashDrawerRepository.GetById(id);
            _uow.CashDrawerRepository.Delete(cashDrawer);
        }
    }
}
