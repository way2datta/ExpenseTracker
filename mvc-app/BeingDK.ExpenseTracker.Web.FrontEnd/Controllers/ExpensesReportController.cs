using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeingDK.ExpenseTracker.Web.FrontEnd.Models;

namespace BeingDK.ExpenseTracker.Web.FrontEnd.Controllers
{
    [Authorize]
    public class ExpensesReportController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ExpensesReportViewModel { SelectedMonth = DateTime.Now});
        }

        [HttpPost]
        public ActionResult Index(ExpensesReportViewModel model)
        {
            return View(model.Get());
        }
    }
}