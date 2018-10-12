using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using BeingDK.ExpenseTracker.Data;
using BeingDK.ExpenseTracker.Web.FrontEnd.Models;

namespace BeingDK.ExpenseTracker.Web.FrontEnd.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDataContext db = new AppDataContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,UserName,Password,Email,Phone,Address,BirthDate,Gender,AlternatePhone,RegistrationDate,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,UserName,Password,Email,Phone,Address,BirthDate,Gender,AlternatePhone,RegistrationDate,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;

                var loggedInUserId = int.Parse(((FormsIdentity)User.Identity).Ticket.UserData);
                user.UpdatedBy = loggedInUserId;
                user.UpdatedAt = DateTime.Now;

                db.SaveChanges();
                return RedirectToRoute("Home");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
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