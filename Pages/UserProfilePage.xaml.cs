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
    /// Interaction logic for UserProfilePage.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        public UserProfilePage()
        {
            InitializeComponent();
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserProfileBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditCoverImageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsFrame.Source = new Uri("/UserControls/UserDetails/ProfileDetailsControl.xaml", UriKind.Relative);
        }

        private void IncomeBtn_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsFrame.Source = new Uri("/UserControls/UserDetails/IncomeDetailsControl.xaml", UriKind.Relative);
        }

        private void LocationBtn_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsFrame.Source = new Uri("/UserControls/UserDetails/ProfileDetailsControl.xaml", UriKind.Relative);
        }

        private void BudgetBtn_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsFrame.Source = new Uri("/UserControls/UserDetails/BudgetDetailsControl.xaml", UriKind.Relative);
        }
    }
}
