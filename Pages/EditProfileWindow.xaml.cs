using Expenser.Models;
using Expenser.ViewModel;
using System.Windows;

namespace Expenser.Pages
{
    /// <summary>
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        public EditProfileViewModel EditProfileViewModel { get; private set; }
        public EditProfileWindow(EditProfileViewModel editProfileViewModel)
        {
            InitializeComponent();

            Func.LoadUserDetails();

            EditProfileViewModel = editProfileViewModel;
            //var userDetails = Func.GetUserDetails();
            this.DataContext = EditProfileViewModel;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //var user = UserSession.CurrentUser;

            if (EditProfileViewModel == null)
            {
                MessageBox.Show("User data not found.");
                return;
            }

            //var userDto = new UserDto
            //{
            //    Username = user.Username,
            //    Name = NameBox.Text,
            //    Email = EmailBox.Text,
            //    Contact = ContactBox.Text,
            //    Gender = GenderBox.Text,
            //    Country = CountryBox.Text,
            //    DOB = DobDatePicker.SelectedDate ?? DateTime.Now,
            //    PreferredCurrency = PrefCurrencyBox.Text,
            //};

            Func.SaveUserDetails(EditProfileViewModel);

            DialogResult = true;
        }
    }
}
