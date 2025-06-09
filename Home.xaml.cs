using System.Windows;

namespace Expenser
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void HomeCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HomeMinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            GetWindow(this).WindowState = WindowState.Minimized;
        }
    }
}
