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
            return _uow.CashDrawerRepository.GetAll();
        }

        // GET: api/CashDrawers/5
        [HttpGet("id/{id}")]
        public CashDrawer Get(int id)
        {
            return _uow.CashDrawerRepository.GetById(id);
        }

        //// POST: api/CashDrawers
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/CashDrawers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CashDrawer cashDrawer)
        {
            _uow.CashDrawerRepository.Update(cashDrawer);
            _uow.Save();
        }
        
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
