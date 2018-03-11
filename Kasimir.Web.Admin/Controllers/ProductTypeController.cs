//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Kasimir.Core.Entities;
//using Kasimir.Web.Admin.Models;
//using Kasimir.Core.Contracts;
//using Kasimir.Web.Admin.ViewModels;
//using System.Data;
//using Kasimir.Core;

//namespace Kasimir.Web.Admin.Controllers
//{
//    public class ProductTypeController : Controller
//    {
//        private readonly IUnitOfWork _uow;

//        public ProductTypeController (IUnitOfWork uow)
//        {
//            _uow = uow;
//        }

//        // GET: ProductTypes
//        public IActionResult Index()
//        {
//            var productTypeOverview = _uow.ProductRepository.GetAll().ToArray();            
//            return View(productTypeOverview);
//        }

//        // GET: ProductTypes/Details/5
//        public IActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var productType =  _uow.ProductTypeRepository.GetAll()
//                .SingleOrDefault(m => m.Id == id);
//            if (productType == null)
//            {
//                return NotFound();
//            }

//            return View(productType);
//        }

//        // GET: ProductTypes/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: ProductTypes/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create([Bind("Status,Number,Name,GrossPrice,NetPrice,Barcode,IsActive,Id,RowVersion")] Product productType)
//        {
//            if (productType.IsActive)
//            {
//                productType.Status = ItemStatus.Active;
//            }
//            else
//            {
//                productType.Status = ItemStatus.Inactive;
//            }
//            if (ModelState.IsValid)
//            {
//                _uow.ProductTypeRepository.Add(productType);
//                try
//                {
//                    _uow.Save();
//                }
//                catch (Exception ex)
//                {
//                    ModelState.AddModelError("ProductType", ex.Message);
//                }          
//                return RedirectToAction(nameof(Index));
//            }
//            return View(productType);
//        }

//        // GET: ProductTypes/Edit/5
//        public IActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var productType = _uow.ProductTypeRepository.GetAll().SingleOrDefault(m => m.Id == id);
//            if (productType == null)
//            {
//                return NotFound();
//            }
//            return View(productType);
//        }

//        // POST: ProductTypes/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(int id, [Bind("Status,Number,Name,GrossPrice,NetPrice,Barcode,IsActive,Id,RowVersion")] Product productType)
//        {
//            if (id != productType.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                if (productType.IsActive)
//                {
//                    productType.Status = ItemStatus.Active;
//                }
//                else
//                {
//                    productType.Status = ItemStatus.Inactive;
//                }
                
//                try
//                {
//                    _uow.ProductTypeRepository.Update(productType);
//                    _uow.Save();
//                    return RedirectToAction(nameof(Index));
//                }
//                catch (DbUpdateException dbUpdateException)
//                {
//                    ModelState.AddModelError("Database update exception", dbUpdateException.Message);
//                }
//                return RedirectToAction(nameof(Edit));
//            }
//            return View(productType);
//        }

//        // GET: ProductTypes/Delete/5
//        public IActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var productType = _uow.ProductTypeRepository.GetAll()
//                .SingleOrDefault(m => m.Id == id);
//            if (productType == null)
//            {
//                return NotFound();
//            }

//            return View(productType);
//        }

//        // POST: ProductTypes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var productType = _uow.ProductTypeRepository.GetAll().SingleOrDefault(m => m.Id == id);
//            _uow.ProductTypeRepository.Delete(productType);
//            _uow.Save();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ProductTypeExists(int id)
//        {
//            return _uow.ProductTypeRepository.GetAll().Any(e => e.Id == id);
//        }
//    }
//}
