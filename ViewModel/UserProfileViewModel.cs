using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Expenser.ViewModel
{
    public class UserProfileViewModel
    {
        private string _userName;
        private string _profileImagePath;
        private BitmapImage _profileImage;
        private string _initialText;
        private Visibility _profileImageVisibility;
        private Visibility _initialTextVisibility;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                    UpdateUserDisplay();
                }
            }
        }

        public string ProfileImagePath
        {
            get { return _profileImagePath; }
            set
            {
                if (_profileImagePath != value)
                {
                    _profileImagePath = value;
                    OnPropertyChanged();
                    UpdateUserDisplay();
                }
            }
        }

        public BitmapImage ProfileImage
        {
            get { return _profileImage; }
            private set
            {
                _profileImage = value;
                OnPropertyChanged();
            }
        }

        public string InitialText
        {
            get { return _initialText; }
            private set
            {
                _initialText = value;
                OnPropertyChanged();
            }
        }

        public Visibility ProfileImageVisibility
        {
            get { return _profileImageVisibility; }
            private set
            {
                _profileImageVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility InitialTextVisibility
        {
            get { return _initialTextVisibility; }
            private set
            {
                _initialTextVisibility = value;
                OnPropertyChanged();
            }
        }

        private void UpdateUserDisplay()
        {
            if (!string.IsNullOrWhiteSpace(ProfileImagePath) && File.Exists(ProfileImagePath))
            {
                try
                {
                    BitmapImage image = new BitmapImage(new Uri(ProfileImagePath, UriKind.Absolute));
                    ProfileImageVisibility = Visibility.Visible;
                    InitialTextVisibility = Visibility.Visible;
                    InitialText = string.IsNullOrWhiteSpace(UserName) ? "?" : UserName.Substring(0, 1).ToUpper();
                }
                catch
                {
                    ShowInitial();
                }
            }
            else
            {
                ShowInitial();
            }
        }

        private void ShowInitial()
        {
            ProfileImageVisibility = Visibility.Collapsed;
            InitialTextVisibility = Visibility.Visible;
            InitialText = string.IsNullOrWhiteSpace(UserName) ? "?" : UserName.Substring(0, 1).ToUpper();
        }
    }
}
