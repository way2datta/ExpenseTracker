using System;

namespace BeingDK.ExpenseTracker.Data
{
  public partial class ExpenseCategoryViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
  }
}
