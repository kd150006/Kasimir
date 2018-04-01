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
        public async Task<IActionResult> Get()
        {
            var result = await _uow.CashDrawerRepository.GetAll();
            return Ok(result);
        }

        // GET: api/CashDrawers/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _uow.CashDrawerRepository.GetById(id);
            return Ok(result);
        }
        
        // PUT: api/CashDrawers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]CashDrawer cashDrawer)
        {
            if (cashDrawer == null)
            {
                return NotFound();
            }
            _uow.CashDrawerRepository.Update(cashDrawer);
            await _uow.Save();
            return Ok(cashDrawer);
        }        
    }
}
