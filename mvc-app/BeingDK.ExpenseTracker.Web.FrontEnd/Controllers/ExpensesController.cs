using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using BeingDK.ExpenseTracker.Web.FrontEnd.Models;

namespace BeingDK.ExpenseTracker.Web.FrontEnd.Controllers
{
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly AppDataContext db = new AppDataContext();

        [HttpGet]
        public ActionResult Index()
        {
            var expenses = db.Expenses.Include(e => e.ExpenseCategory)
                                      .Include(e => e.User)
                                      .Include(e => e.User1)
                                      .Include(e => e.User2);
            return View(expenses.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.ExpenseCategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Amount,Description,CategoryId,IncurredAt,IncurredBy,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserId = int.Parse(((FormsIdentity)User.Identity).Ticket.UserData);
                expense.IncurredBy = loggedInUserId;
                expense.CreatedBy = loggedInUserId;
                expense.UpdatedBy = loggedInUserId;
                expense.CreatedAt = DateTime.Now;
                expense.UpdatedAt = DateTime.Now;

                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount,Description,CategoryId,IncurredAt,IncurredBy,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserId = int.Parse(((FormsIdentity)User.Identity).Ticket.UserData);
                expense.UpdatedBy = loggedInUserId;
                expense.UpdatedAt = DateTime.Now;

                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var expense = db.Expenses.Find(id);
            db.Expenses.Remove(expense);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }
    }
}