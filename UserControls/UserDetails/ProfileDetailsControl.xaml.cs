using Expenser.Models;
using System.Windows.Controls;

namespace Expenser.UserControls.UserDetails
{
    /// <summary>
    /// Interaction logic for ProfileDetailsControl.xaml
    /// </summary>
    public partial class ProfileDetailsControl : UserControl
    {
        public ProfileDetailsControl()
        {
            InitializeComponent();

            Func.LoadUserDetails();
            
            this.DataContext = Func.GetUserDetails();
        }
    }
}
