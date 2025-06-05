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

namespace Expenser.Pages
{
    /// <summary>
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        public EditProfileWindow()
        {
            InitializeComponent();

            Func.LoadUserDetails();
            var userDetails = Func.GetUserDetails();
            this.DataContext = userDetails;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = UserSession.CurrentUser;

            if (user == null)
            {
                MessageBox.Show("User not found.");
                return;
            }

            var userDto = new UserDto
            {
                Username = user.Username,
                Name = NameBox.Text,
                Email = EmailBox.Text,
                Contact = ContactBox.Text,
                Gender = GenderBox.Text,
                Country = CountryBox.Text,
                DOB = DobDatePicker.SelectedDate ?? DateTime.Now,
                PreferredCurrency = PrefCurrencyBox.Text,
            };

            Func.SaveUserDetails(userDto);
        }
    }
}
