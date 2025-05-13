using Expenser.Models;
using Expenser.Pages.NewExpense;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Expenser.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            if (UserSession.CurrentUser == null)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();

                mainWindow.MainFrame.Navigate(new LoginPage());

                Window.GetWindow(this)?.Close();
            }
            else
            {
                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            var user = UserSession.CurrentUser;
            if (user != null)
            {
                UserTxt.Text = $"{user.Username}!";
            }
        }
    }
}
