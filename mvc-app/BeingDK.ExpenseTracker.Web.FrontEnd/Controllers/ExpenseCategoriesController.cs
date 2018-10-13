using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using BeingDK.ExpenseTracker.Data;

namespace BeingDK.ExpenseTracker.Web.FrontEnd.Controllers
{
    [Authorize]
    public class ExpenseCategoriesController : Controller
    {
        private readonly AppDataContext dbContext = new AppDataContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View(dbContext.ExpenseCategories.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseCategory = dbContext.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserId = int.Parse(((FormsIdentity)User.Identity).Ticket.UserData);
                expenseCategory.CreatedBy = loggedInUserId;
                expenseCategory.UpdatedBy = loggedInUserId;
                expenseCategory.CreatedAt = DateTime.Now;
                expenseCategory.UpdatedAt = DateTime.Now;

                dbContext.ExpenseCategories.Add(expenseCategory);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(expenseCategory);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseCategory = dbContext.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedAt,CreatedBy")] ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserId = int.Parse(((FormsIdentity)User.Identity).Ticket.UserData);
                expenseCategory.UpdatedBy = loggedInUserId;
                expenseCategory.UpdatedAt = DateTime.Now;

                dbContext.Entry(expenseCategory).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseCategory);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expenseCategory = dbContext.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var expenseCategory = dbContext.ExpenseCategories.Find(id);
            dbContext.ExpenseCategories.Remove(expenseCategory);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            dbContext.Dispose();
        }
    }
}