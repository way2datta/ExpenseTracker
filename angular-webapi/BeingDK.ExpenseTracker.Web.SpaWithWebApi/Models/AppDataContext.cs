namespace BeingDK.ExpenseTracker.Web.SpaWithWebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppDataContext : DbContext
    {
        public AppDataContext()
            : base("name=AppDataContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }


        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public virtual DbSet<ExpenseCategoryMaster> ExpenseCategoryMasters { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseCategory>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.ExpenseCategory)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Expenses1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.IncurredBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Expenses2)
                .WithRequired(e => e.User2)
                .HasForeignKey(e => e.UpdatedBy)
                .WillCascadeOnDelete(false);
        }
    }
}
