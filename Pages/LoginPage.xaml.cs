using Expenser.Models;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Expenser.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            UsernameTxt.Focus();
            UsernameTxt.Text = "vishal kumar";
            PasswordTxt.Password = "12345678";
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTxt.Text;
            string password = PasswordTxt.Password;
            bool rememberMe = RememberMeChk.IsChecked ?? false;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (var dbContext = new ApplicationDbContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Username == username);

                if (user == null || !VerifyPassword(password, user.Password))
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }

                // Store user session
                UserSession.CurrentUser = user;
                // Optionally, you can store the user session in a more secure way
                // e.g., using a secure token or session management system
                // For simplicity, we are just storing the user object in a static property
                // UserSession.CurrentUser = user;  
            }

            if (rememberMe)
            {
                UserSession.SaveCredentials(username);
            }
            else
            {
                UserSession.ClearSavedCredentials();
            }

            // Navigate to the home page
            Home home = new Home();
            home.Show();

            Window mainWindow = Window.GetWindow(this);
            mainWindow?.Close();
        }

        private void CreateAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/SignupPage.xaml", UriKind.Relative));
        }

        private void ForgotPassBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/ForgotPassPage.xaml", UriKind.Relative));
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                string hashedPassword = Convert.ToBase64String(hashedBytes);
                return hashedPassword == storedPassword;
            }
        }

        private void LoadSavedCredentials()
        {
            if (Properties.Settings.Default.RememberMe)
            {
                UsernameTxt.Text = Properties.Settings.Default.SavedUsername;
                RememberMeChk.IsChecked = true;
            }
        }
    }
}
