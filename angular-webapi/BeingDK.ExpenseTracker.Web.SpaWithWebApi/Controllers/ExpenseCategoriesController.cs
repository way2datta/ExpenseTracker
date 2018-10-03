using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BeingDK.ExpenseTracker.Web.SpaWithWebApi.Models;

namespace BeingDK.ExpenseTracker.Web.SpaWithWebApi.Controllers
{
    public class ExpenseCategoriesController : ApiController
    {
        private AppDataContext db = new AppDataContext();

        // GET: api/ExpenseCategories
        public IQueryable<ExpenseCategory> GetExpenseCategories()
        {
            return db.ExpenseCategories;
        }

        // GET: api/ExpenseCategories/5
        [ResponseType(typeof(ExpenseCategory))]
        public IHttpActionResult GetExpenseCategory(int id)
        {
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            return Ok(expenseCategory);
        }

        // PUT: api/ExpenseCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExpenseCategory(int id, ExpenseCategory expenseCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expenseCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(expenseCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ExpenseCategories
        [ResponseType(typeof(ExpenseCategory))]
        public IHttpActionResult PostExpenseCategory(ExpenseCategory expenseCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExpenseCategories.Add(expenseCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = expenseCategory.Id }, expenseCategory);
        }

        // DELETE: api/ExpenseCategories/5
        [ResponseType(typeof(ExpenseCategory))]
        public IHttpActionResult DeleteExpenseCategory(int id)
        {
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            db.ExpenseCategories.Remove(expenseCategory);
            db.SaveChanges();

            return Ok(expenseCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseCategoryExists(int id)
        {
            return db.ExpenseCategories.Count(e => e.Id == id) > 0;
        }
    }
}