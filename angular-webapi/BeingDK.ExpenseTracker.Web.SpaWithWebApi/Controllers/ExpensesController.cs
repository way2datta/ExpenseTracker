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
    private AppDataContext db = new AppDataContext();

    [HttpGet]
    public IQueryable<Expense> GetExpenses()
    {
      return db.Expenses.Include(x => x.ExpenseCategory);
    }

    [HttpGet]
    [ResponseType(typeof(Expense))]
    public IHttpActionResult GetExpense(int id)
    {
      Expense expense = db.Expenses.Find(id);
      if (expense == null)
      {
        return NotFound();
      }

      return Ok(expense);
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
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool ExpenseExists(int id)
    {
      return db.Expenses.Count(e => e.Id == id) > 0;
    }
  }
}
