using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kasimir.Web.Admin.Controllers
{
    public class StockController : Controller
    {
        private readonly IUnitOfWork _uow;
        public StockController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Stock
        public ActionResult Index()
        {
            var stockOverview = _uow.StockRepository.GetAll().ToArray();
            return View(stockOverview);
        }

        // GET: Stock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = _uow.StockRepository.GetAll()
                .SingleOrDefault(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stock/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stock/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Status,Name,IsActive,Id,RowVersion")] Stock stock)
        {
            if (stock.IsActive)
            {
                stock.Status = ItemStatus.Active;
            }
            else
            {
                stock.Status = ItemStatus.Inactive;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _uow.StockRepository.Add(stock);
                    _uow.Save();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Stock", ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // GET: Stock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = _uow.StockRepository.GetAll().SingleOrDefault(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }

        // POST: Stock/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Status,Name,IsActive,Id,RowVersion")] Stock stock)
        {
            if (id != stock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (stock.IsActive)
                {
                    stock.Status = ItemStatus.Active;
                }
                else
                {
                    stock.Status = ItemStatus.Inactive;
                }

                try
                {
                    _uow.StockRepository.Update(stock);
                    _uow.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    ModelState.AddModelError("Database update exception", dbUpdateException.Message);
                }
                return RedirectToAction(nameof(Edit));
            }
            return View(stock);
        }

        // GET: Stock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = _uow.StockRepository.GetAll()
                .SingleOrDefault(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var stock = _uow.StockRepository.GetAll().SingleOrDefault(m => m.Id == id);
            _uow.StockRepository.Delete(stock);
            _uow.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int id)
        {
            return _uow.StockRepository.GetAll().Any(e => e.Id == id);
        }
    }
}