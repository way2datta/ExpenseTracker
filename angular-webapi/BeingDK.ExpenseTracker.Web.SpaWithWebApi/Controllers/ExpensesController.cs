using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BeingDK.ExpenseTracker.Data;

namespace BeingDK.ExpenseTracker.Web.SpaWithWebApi.Controllers
{
  public class ExpensesController : ApiController
  {
    private readonly AppDataContext db = new AppDataContext();

    [HttpGet]
    public IQueryable<ExpenseViewModel> GetExpenses()
    {
      return db.Expenses.Include(x => x.ExpenseCategory)
                        .Select(x => new ExpenseViewModel
                        {
                          Amount = x.Amount,
                          CategoryId = x.CategoryId,
                          CreatedAt = x.CreatedAt,
                          CreatedBy = x.CreatedBy,
                          Description = x.Description,
                          ExpenseCategory = new ExpenseCategoryViewModel { Id = x.ExpenseCategory.Id, Name = x.ExpenseCategory.Name },
                          Id = x.Id,
                          IncurredAt = x.IncurredAt,
                          IncurredBy = x.IncurredBy,
                          UpdatedAt = x.UpdatedAt,
                          UpdatedBy = x.UpdatedBy
                        });
    }

    [HttpGet]
    [ResponseType(typeof(Expense))]
    public IHttpActionResult GetExpense(int id)
    {
      Expense expense = db.Expenses.Include(x => x.ExpenseCategory).First(x => x.Id == id);
      if (expense == null)
      {
        return NotFound();
      }

      return Ok(new ExpenseViewModel
      {
        Amount = expense.Amount,
        CategoryId = expense.CategoryId,
        CreatedAt = expense.CreatedAt,
        CreatedBy = expense.CreatedBy,
        Description = expense.Description,
        ExpenseCategory = new ExpenseCategoryViewModel { Id = expense.ExpenseCategory.Id, Name = expense.ExpenseCategory.Name },
        Id = expense.Id,
        IncurredAt = expense.IncurredAt,
        IncurredBy = expense.IncurredBy,
        UpdatedAt = expense.UpdatedAt,
        UpdatedBy = expense.UpdatedBy
      });
    }

    [HttpPut]
    [ResponseType(typeof(void))]
    public IHttpActionResult PutExpense(int id, Expense expense)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != expense.Id)
      {
        return BadRequest();
      }

      expense.ExpenseCategory = null;
      db.Entry(expense).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ExpenseExists(id))
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

    [HttpPost]
    [ResponseType(typeof(Expense))]
    public IHttpActionResult PostExpense(Expense expense)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      // TODO: Dirty way of doing it, I'll get rid of it later
      expense.CreatedAt = DateTime.Now;
      expense.UpdatedAt = DateTime.Now;
      expense.CreatedBy = 1;
      expense.IncurredBy = 1;
      expense.UpdatedBy = 1;

      db.Expenses.Add(expense);
      db.SaveChanges();

      return CreatedAtRoute("DefaultApi", new { id = expense.Id }, expense);
    }

    [HttpDelete]
    [ResponseType(typeof(Expense))]
    public IHttpActionResult DeleteExpense(int id)
    {
      Expense expense = db.Expenses.Find(id);
      if (expense == null)
      {
        return NotFound();
      }

      db.Expenses.Remove(expense);
      db.SaveChanges();

      return Ok(expense);
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      db.Dispose();
    }

    private bool ExpenseExists(int id)
    {
      return db.Expenses.Count(e => e.Id == id) > 0;
    }
  }
}
