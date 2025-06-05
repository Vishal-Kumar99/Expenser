using Expenser.Models;
using Expenser.Pages.ExpenseType;
using Expenser.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Expenser.Pages
{
    /// <summary>
    /// Interaction logic for UserProfilePage.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        public EditProfileViewModel _editProfileViewModel { get; set; }
        public UserProfilePage()
        {
            InitializeComponent();

            var user = UserSession.CurrentUser;
            
            if (user != null )
            {
                this.DataContext = new UserProfileViewModel
                {
                    UserName = user.Username,
                    ProfileImagePath = user.ProfileImagePath
                };
            }

            _editProfileViewModel = Func.GetUserDetails();
            UserDetailsFrame.Content = new UserControls.UserDetails.ProfileDetailsControl { DataContext = _editProfileViewModel };
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/HomePage.xaml", UriKind.Relative));
        }

        private void SettingBtn_Click(object sender, RoutedEventArgs e)
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

        private void EditProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EditProfileWindow(_editProfileViewModel);
            Window window = Window.GetWindow(this);
            dialog.Owner = window;
            if (dialog.ShowDialog() == true)
            {
                Func.LoadUserDetails();
                var updateVm = Func.GetUserDetails();
                _editProfileViewModel.UpdateForm(updateVm);
            }
        }

        //public static readonly DependencyProperty UserNameProperty =
        //   DependencyProperty.Register("UserName", typeof(string), typeof(UserProfilePage), new PropertyMetadata(string.Empty, OnUserNameChanged));

        //public static readonly DependencyProperty ProfileImagePathProperty =
        //    DependencyProperty.Register("ProfileImagePath", typeof(string), typeof(UserProfilePage), new PropertyMetadata(string.Empty, OnProfileImagePathChanged));

        //public string UserName
        //{
        //    get { return (string)GetValue(UserNameProperty); }
        //    set { SetValue(UserNameProperty, value); }
        //}

        //public string ProfileImagePath
        //{
        //    get { return (string)GetValue(ProfileImagePathProperty); }
        //    set { SetValue(ProfileImagePathProperty, value); }
        //}

        //public static void OnUserNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var control = d as UserProfilePage;
        //    control?.UpdateUserDisplay();
        //}

        //public static void OnProfileImagePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var control = d as UserProfilePage;
        //    control?.UpdateUserDisplay();
        //}

        //private void UpdateUserDisplay()
        //{
        //    UsernameTxt.Text = UserName;

        //    if (!string.IsNullOrWhiteSpace(ProfileImagePath) && File.Exists(ProfileImagePath))
        //    {
        //        try
        //        {
        //            BitmapImage image = new BitmapImage(new Uri(ProfileImagePath, UriKind.Absolute));
        //            ProfileImage.Source = image;
        //            ProfileImage.Visibility = Visibility.Visible;
        //            InitialText.Visibility = Visibility.Visible;
        //        }
        //        catch
        //        {
        //            ShowInitial();
        //        }
        //    }
        //    else
        //    {
        //        ShowInitial();
        //    }
        //}

        //private void ShowInitial()
        //{
        //    ProfileImage.Visibility = Visibility.Collapsed;
        //    InitialText.Visibility = Visibility.Visible;
        //    InitialText.Text = string.IsNullOrWhiteSpace(UserName) ? "?" : UserName[0].ToString().ToUpper();
        //}
    }
}
