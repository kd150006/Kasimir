using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kasimir.Web.Admin.Models;
using Kasimir.Web.Admin.ViewModels;
using Kasimir.Core.Contracts;

namespace Kasimir.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uow;
        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductType()
        {
            return RedirectToAction("Index", "ProductType");
            //var url = Url.Action("Index", "ProductType");
            //return Content(url);
            //return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
