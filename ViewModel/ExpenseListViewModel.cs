using Expenser.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;

namespace Expenser.ViewModel
{
    public class ExpenseListViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Expense> Expenses { get; set; }
        public ICollectionView ExpenseView { get; set; }
        //private ObservableCollection<Expense> _filteredExpenses;
        //public ObservableCollection<Expense> FilteredExpenses
        //{
        //    get => _filteredExpenses;
        //    set
        //    {
        //        _filteredExpenses = value;
        //        OnPropertyChanged(nameof(FilteredExpenses));
        //    }
        //}

        private string _searchBox;
        public string SearchBox
        {
            get => _searchBox;
            set
            {
                if (_searchBox != value)
                {
                    _searchBox = value;
                    OnPropertyChanged(nameof(SearchBox));
                    ExpenseView.Refresh();
                    //FilterExpenses();
                }
            }
        }

        public ExpenseListViewModel()
        {
            Expenses = new ObservableCollection<Expense>()
            {
                new Expense { Id = 1, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "A Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 2, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "B Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 3, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "C Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 4, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "D Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 5, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "E Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 6, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "F Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 7, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Entertainment Expense abcdefghijklmnopqrstuvwxyz", ExpenseType = new ExpenseType { Type = "Entertainment" }},
                new Expense { Id = 8, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Electricity Bill", ExpenseType = new ExpenseType { Type = "Electricity" }},
                new Expense {Id = 9, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Youtube Subscription", ExpenseType = new ExpenseType { Type = "Subscription" }},
                new Expense { Id = 1, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "A Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 2, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "B Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 3, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "C Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 4, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "D Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 5, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "E Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 6, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "F Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 7, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Entertainment Expense", ExpenseType = new ExpenseType { Type = "Entertainment" }},
                new Expense { Id = 8, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Electricity Bill", ExpenseType = new ExpenseType { Type = "Electricity" }},
                new Expense {Id = 9, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Youtube Subscription", ExpenseType = new ExpenseType { Type = "Subscription" }},
                new Expense { Id = 1, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "A Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 2, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "B Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 3, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "C Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 4, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "D Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 5, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "E Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 6, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "F Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 7, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Entertainment Expense", ExpenseType = new ExpenseType { Type = "Entertainment" }},
                new Expense { Id = 8, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Electricity Bill", ExpenseType = new ExpenseType { Type = "Electricity" }},
                new Expense {Id = 9, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Youtube Subscription", ExpenseType = new ExpenseType { Type = "Subscription" }},
                new Expense { Id = 1, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "A Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 2, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "B Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 3, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "C Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 4, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "D Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 5, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "E Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 6, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "F Travel Expense", ExpenseType = new ExpenseType { Type = "Travel" } },
                new Expense { Id = 7, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Entertainment Expense", ExpenseType = new ExpenseType { Type = "Entertainment" }},
                new Expense { Id = 8, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Electricity Bill", ExpenseType = new ExpenseType { Type = "Electricity" }},
                new Expense {Id = 9, UserId = 0, Amount = 0, Date = DateTime.Now, Title = "Youtube Subscription", ExpenseType = new ExpenseType { Type = "Subscription" }}
            };

            ExpenseView = CollectionViewSource.GetDefaultView(Expenses);
            ExpenseView.Filter = FilterExpenses;
            ExpenseView.Refresh();
            //FilteredExpenses = new ObservableCollection<Expense>(Expenses);

            //LoadExpenseList();
        }

        private bool FilterExpenses(object obj)
        {
            if (obj is not Expense expense) return false;

            if (string.IsNullOrWhiteSpace(SearchBox)) return true;

            return (expense.Title?.IndexOf(SearchBox, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (expense.ExpenseType?.Type?.IndexOf(SearchBox, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        //private void LoadExpenseList()
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        var expenses = context.Expenses.ToList();
        //        Expenses.Clear();
        //        foreach (var expense in expenses)
        //        {
        //            Expenses.Add(expense);
        //        }
        //    }
        //}

        //private void FilterExpenses()
        //{
        //    if (_filteredExpenses == null)
        //    {
        //        _filteredExpenses = new ObservableCollection<Expense>();
        //    }
        //    Debug.WriteLine($"Filtering expenses with SearchBox: {SearchBox}");

        //    _filteredExpenses.Clear();

        //    IEnumerable<Expense> filtered = string.IsNullOrWhiteSpace(SearchBox) ? Expenses : Expenses.Where(e =>
        //            (!string.IsNullOrEmpty(e.Title) && e.Title.Contains(SearchBox, StringComparison.OrdinalIgnoreCase)) ||
        //            (e.ExpenseType != null && !string.IsNullOrEmpty(e.ExpenseType.Type) &&
        //                e.ExpenseType.Type.Contains(SearchBox, StringComparison.OrdinalIgnoreCase)));

        //    foreach (var item in filtered)
        //    {
        //        _filteredExpenses.Add(item);
        //    }

        //    OnPropertyChanged(nameof(FilteredExpenses));
        //}
    }
}
