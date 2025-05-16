using Expenser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Expenser.Pages.ExpenseType
{
    /// <summary>
    /// Interaction logic for ExpenseTypeWindow.xaml
    /// </summary>
    public partial class ExpenseTypeWindow : Window
    {
        public ExpenseTypeWindow()
        {
            InitializeComponent();

            Func.LoadExpenseType(EditTypeCBox, DeleteTypeCBox, TypeList);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void AddTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            var type = NewTypeBox.Text;

            if (string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Please fill in the textbox.");
            }
            else
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var expenseType = new Models.ExpenseType
                    {
                        Type = type,
                    };

                    dbContext.ExpenseTypes.Add(expenseType);
                    dbContext.SaveChanges();

                }
                MessageBox.Show($"{type} is added in list.");
                NewTypeBox.Clear();
            }

            Func.LoadExpenseType(EditTypeCBox, DeleteTypeCBox, TypeList);
        }

        private void EditTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            var typedType = EditTypeCBox.Text;

            if (string.IsNullOrWhiteSpace(typedType))
            {
                MessageBox.Show("Please enter a valid Expense Type.", "Invalid Type", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var selectedType = EditTypeCBox.SelectedItem as Models.ExpenseType;

                    if (selectedType != null)
                    {
                        var expenseType = dbContext.ExpenseTypes.FirstOrDefault(e => e.Id == selectedType.Id);

                        if (expenseType != null)
                        {
                            expenseType.Type = typedType;
                            dbContext.SaveChanges();
                            MessageBox.Show($"'{selectedType.Type}' has been updated to '{typedType}'.", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select an Expense Type", "Invalid Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }

            Func.LoadExpenseType(EditTypeCBox, DeleteTypeCBox, TypeList);
        }

        private void DeleteTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedType = DeleteTypeCBox.SelectedItem as Models.ExpenseType;

            if (selectedType == null)
            {
                MessageBox.Show("Please select an Expense Type to delete.", "Invalid Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var ConfirmResult = MessageBox.Show($"Are you sure you want to delete '{selectedType.Type}'?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (ConfirmResult == MessageBoxResult.Yes)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var expenseType = dbContext.ExpenseTypes.FirstOrDefault(e => e.Id == selectedType.Id);

                    if (expenseType != null)
                    {
                        dbContext.ExpenseTypes.Remove(expenseType);
                        dbContext.SaveChanges();
                        MessageBox.Show($"'{selectedType.Type}' has been deleted.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("The selectd Expense Type could not be found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                Func.LoadExpenseType(EditTypeCBox, DeleteTypeCBox, TypeList);
            }
        }

        
    }
}
