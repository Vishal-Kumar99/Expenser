using Expenser.Models;
using Expenser.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Expenser.UserControls
{
    /// <summary>
    /// Interaction logic for UserProfileControl.xaml
    /// </summary>
    public partial class UserProfileControl : UserControl
    {
        //public static readonly DependencyProperty UserNameProperty =
        //    DependencyProperty.Register("UserName", typeof(string), typeof(UserProfileControl), new PropertyMetadata(string.Empty, OnUserNameChanged));

        //public static readonly DependencyProperty ProfileImagePathProperty =
        //    DependencyProperty.Register("ProfileImagePath", typeof(string), typeof(UserProfileControl), new PropertyMetadata(string.Empty, OnProfileImagePathChanged));

        public event EventHandler ProfileClicked;

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

        public UserProfileControl()
        {
            InitializeComponent();

            var user = UserSession.CurrentUser;
            if (user != null)
            {
                this.DataContext = new UserProfileViewModel
                {
                    UserName = user.Username,
                    ProfileImagePath = user.ProfileImagePath
                };
            }
        }

        //public static void OnUserNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var control = d as UserProfileControl;
        //    control?.UpdateUserDisplay();
        //}

        //public static void OnProfileImagePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var control = d as UserProfileControl;
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

        private void OnProfileClicked(object sender, MouseButtonEventArgs e)
        {
            ProfileClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
