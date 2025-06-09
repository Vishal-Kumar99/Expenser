using Expenser.Models;
using System.Collections.ObjectModel;

namespace Expenser.ViewModel
{
    public class ExpenseListViewModel
    {
        public ObservableCollection<Expense> Expenses { get; set; }

        public ExpenseListViewModel()
        {
            Expenses = new ObservableCollection<Expense>()
            {
                new Expense { Id = 1, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 2, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Entertainment Expense", ExpenseType = new ExpenseType { Type = "Entertainment" }},
                new Expense { Id = 3, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Electricity Bill", ExpenseType = new ExpenseType { Type = "Electricity" }},
                new Expense {Id = 4, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Youtube Subscription", ExpenseType = new ExpenseType { Type = "Subscription" }},
                new Expense { Id = 5, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 6, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Entertainment Expense", ExpenseType = new ExpenseType { Type = "Entertainment" }},
                new Expense { Id = 7, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Electricity Bill", ExpenseType = new ExpenseType { Type = "Electricity" }},
                new Expense {Id = 8, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Youtube Subscription", ExpenseType = new ExpenseType { Type = "Subscription" }},
                new Expense { Id = 9, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 10, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Entertainment Expense", ExpenseType = new ExpenseType { Type = "Entertainment" }},
                new Expense { Id = 11, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Electricity Bill", ExpenseType = new ExpenseType { Type = "Electricity" }},
                new Expense {Id = 12, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Youtube Subscription", ExpenseType = new ExpenseType { Type = "Subscription" }}
            };

            //LoadExpenseList();
        }

        private void LoadExpenseList()
        {
            using (var context = new ApplicationDbContext())
            {
                var expenses = context.Expenses.ToList();
                Expenses.Clear();
                foreach (var expense in expenses)
                {
                    Expenses.Add(expense);
                }
            }
        }
    }
}
