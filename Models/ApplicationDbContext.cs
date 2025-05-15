using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Expenser.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExpenserDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            modelBuilder.Entity<Expense>().HasOne(e => e.User).WithMany(u => u.Expenses).HasForeignKey(e => e.UserId);
            modelBuilder.Entity<Expense>().HasOne(e => e.ExpenseType).WithMany().HasForeignKey(e => e.ExpenseTypeId);
            modelBuilder.Entity<Expense>().HasOne(e => e.PaymentMethod).WithMany().HasForeignKey(e => e.PaymentMethodId);

            modelBuilder.Entity<Income>().HasOne(i => i.User).WithMany(u => u.Incomes).HasForeignKey(i => i.UserId);
            modelBuilder.Entity<Budget>().HasOne(b => b.User).WithMany(u => u.Budgets).HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Expense>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Income>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Budget>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);
        }
    }

    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string PasswordHint { get; set; }
        public string? ProfileImagePath { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<Income> Incomes { get; set; } = new List<Income>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }

    public class Expense : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime Date { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        public int? ExpenseTypeId { get; set; }
        public int? PaymentMethodId { get; set; }

        public string? Notes { get; set; }
        public string? Tags { get; set; }
        public string? Location { get; set; }

        public ExpenseType? ExpenseType { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public User? User { get; set; }
    }

    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        public required string Type { get; set; }
    }

    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        public required string MethodName { get; set; }
    }

    public class Income : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime Date { get; set; }
        public string? Source { get; set; }

        public User? User { get; set; }
    }

    public class Budget : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }

        public User? User { get; set; }
    }

    public abstract class BaseEntity
    {
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}


// #Relationships Summary
// -----------------------------------------------------------------------
// Table	        |    Relationships
// -----------------------------------------------------------------------
// User	            |    1-to-many with Expense, Income, Budget
// Expense	        |    many-to-1 with User, ExpenseType, PaymentMethod
// ExpenseType	    |    optional many-to-1 with Expense
// PaymentMethod	|    optional many-to-1 with Expense
// Income	        |    many-to-1 with User
// Budget	        |    many-to-1 with User


// #Future Enhancements Suggestions
// -----------------------------------------------------------------------
// 1. Add a RecurringExpense entity if recurring expenses are to be supported.

// 2. Add soft-delete flags (IsDeleted, IsActive) if archiving or logical deletion is required.

// 3. Add Notes, Tags, or Location for each expense for better tracking.

// 4. Enable audit fields like CreatedDate, ModifiedDate, CreatedBy.