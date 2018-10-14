using System;

namespace BeingDK.ExpenseTracker.Data
{
  public class ExpenseViewModel
  {
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public DateTime IncurredAt { get; set; }
    public int IncurredBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public ExpenseCategoryViewModel ExpenseCategory { get; set; }
  }
}
