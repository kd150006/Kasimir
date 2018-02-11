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
    [Route("api/Journals")]
    public class JournalsController : Controller
    {
        private readonly IUnitOfWork _uow;
        public JournalsController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/Journals
        [HttpGet]
        public IEnumerable<Journal> Get()
        {
            var journalsOverview = _uow.JournalRepository.GetAll().ToList();
            return (journalsOverview);
        }

        // GET: api/Journals/5
        [HttpGet("{id}")]
        public Journal Get(int id)
        {
            var journal = _uow.JournalRepository.GetById(id);
            return (journal);
        }
        
        // POST: api/Journals
        [HttpPost]
        public void Post([FromBody]Journal journal)
        {
            _uow.JournalRepository.Add(journal);
            _uow.Save();
        }
        
        // PUT: api/Journals/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Journal journal)
        {
            var journalToUpdate = _uow.JournalRepository.GetById(id);
            _uow.JournalRepository.Update(journalToUpdate);
            _uow.Save();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var journalToDelete = _uow.JournalRepository.GetById(id);
            _uow.JournalRepository.Delete(journalToDelete);
            _uow.Save();
        }
    }
}
