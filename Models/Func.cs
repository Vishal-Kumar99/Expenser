using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Media;
using System.Windows.Controls;


namespace Expenser.Models
{
    public static class Func
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static void LoadExpenseType(params ItemsControl[] controls)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var items = dbContext.ExpenseTypes.ToList();

                foreach (var control in controls)
                {
                    control.ItemsSource = items;

                    if (control is ComboBox comboBox)
                    {
                        comboBox.DisplayMemberPath = "Type";
                        comboBox.SelectedValuePath = "Id";
                        comboBox.SelectedIndex = -1;
                    }
                    else if (control is ListBox listBox)
                    {
                        listBox.DisplayMemberPath = "Type";
                    }
                }
            }
        }
    }
}
