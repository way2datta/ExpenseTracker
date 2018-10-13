using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using BeingDK.ExpenseTracker.Data;

namespace BeingDK.ExpenseTracker.Web.SpaWithWebApi.Controllers
{
  public class ExpenseCategoriesController : ApiController
  {
    private readonly AppDataContext db = new AppDataContext();

    [HttpGet]
    public IQueryable<ExpenseCategoryViewModel> GetExpenseCategories()
    {
      return db.ExpenseCategories.Select(x => new ExpenseCategoryViewModel
      {
        Id = x.Id,
        Name = x.Name
      });
    }

    [HttpGet]
    [ResponseType(typeof(ExpenseCategory))]
    public IHttpActionResult GetExpenseCategory(int id)
    {
      ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
      if (expenseCategory == null)
      {
        return NotFound();
      }

      return Ok(new ExpenseCategoryViewModel
      {
        Id = expenseCategory.Id,
        Name = expenseCategory.Name,
        CreatedAt = expenseCategory.CreatedAt,
        CreatedBy = expenseCategory.CreatedBy,
        UpdatedAt = expenseCategory.UpdatedAt,
        UpdatedBy = expenseCategory.UpdatedBy
      });
    }

    [HttpPut]
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

      return Ok(expenseCategory);
    }

    [HttpPost]
    [ResponseType(typeof(ExpenseCategory))]
    public IHttpActionResult PostExpenseCategory(ExpenseCategory expenseCategory)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      // TODO: Dirty way of doing it, I'll get rid of it later
      expenseCategory.CreatedAt = DateTime.Now;
      expenseCategory.UpdatedAt = DateTime.Now;
      expenseCategory.CreatedBy = 1;
      expenseCategory.UpdatedBy = 1;

      db.ExpenseCategories.Add(expenseCategory);
      db.SaveChanges();

      return CreatedAtRoute("DefaultApi", new { id = expenseCategory.Id }, expenseCategory);
    }

    [HttpDelete]
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
      base.Dispose(disposing);
      db.Dispose();
    }

    private bool ExpenseCategoryExists(int id)
    {
      return db.ExpenseCategories.Count(e => e.Id == id) > 0;
    }
  }
}
