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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kasimir.Web.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _uow;
        public CustomerController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customerOverview = _uow.CustomerRepository.GetAll().ToArray();
            return View(customerOverview);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _uow.CustomerRepository.GetAll()
                .SingleOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            Init(customer);
            customer.IsActive = true;
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName,LastName,Number,Status,TelephoneNumber,EmailAddress,isActive")] Customer customer)
        {
            if (customer.IsActive)
            {
                customer.Status = ItemStatus.Active;
            }
            else
            {
                customer.Status = ItemStatus.Inactive;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _uow.CustomerRepository.Add(customer);
                    _uow.Save();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ProductType", ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _uow.CustomerRepository.GetAll().SingleOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Status,FirstName,LastName,Number,TelephoneNumber,EmailAddress,IsActive,Id,RowVersion")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (customer.IsActive)
                {
                    customer.Status = "A";
                }
                else
                    customer.Status = "I";

                try
                {
                    _uow.CustomerRepository.Update(customer);
                    _uow.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    ModelState.AddModelError("Database update exception", dbUpdateException.Message);
                }
                return RedirectToAction(nameof(Edit));
            }
            return View(customer);
        }

        // GET: ProductTypes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _uow.CustomerRepository.GetAll()
                .SingleOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _uow.CustomerRepository.GetAll().SingleOrDefault(m => m.Id == id);
            _uow.CustomerRepository.Delete(customer);
            _uow.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _uow.CustomerRepository.GetAll().Any(e => e.Id == id);
        }

        private Customer Init(Customer customer)
        {
            customer.FirstName = String.Empty;
            customer.LastName = String.Empty;
            customer.Number = String.Empty;
            customer.TelephoneNumber = null;
            customer.Number = String.Empty;
            return customer;
        }
    }
}