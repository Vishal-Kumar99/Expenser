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
        //public EditProfileViewModel EditProfileViewModel { get; private set; }
        public EditProfileWindow()
        {
            InitializeComponent();

            Func.LoadUserDetails();

            this.DataContext = Func.GetUserDetails();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Func._sharedProfileViewModel == null)
            {
                MessageBox.Show("User data not found.");
                return;
            }

            Func.SaveUserDetails();

            DialogResult = true;
        }
    }
}
