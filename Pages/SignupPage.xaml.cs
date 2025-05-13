using Expenser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Expenser.Pages
{
    /// <summary>
    /// Interaction logic for SignupPage.xaml
    /// </summary>
    public partial class SignupPage : Page
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTxt.Text;
            string password = PasswordTxt.Password;
            string confirmPassword = ConfirmPasswordTxt.Password;
            string passwordHint = PasswordHintTxt.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(passwordHint))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string hashedPassword = Func.HashPassword(password);

            // Save the user to the database

            using (var dbContext = new ApplicationDbContext())
            {
                var user = new User
                {
                    Username = username,
                    Password = hashedPassword,
                    PasswordHint = passwordHint
                };

                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                UserSession.CurrentUser = user;

                Home home = new Home();
                home.Show();

                Window mainWindow = Window.GetWindow(this);
                mainWindow?.Close();
            }
        }

        private void LoginLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/LoginPage.xaml", UriKind.Relative));
        }
    }
}
