using Expenser.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Expenser.ViewModel
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public static ProfileViewModel Instance { get; } = new ProfileViewModel();

        private Brush _profileImage = new SolidColorBrush(Colors.DodgerBlue);
        private string _profileContent = "V";

        public ProfileViewModel()
        {
            UpdateProfileImage(UserSession.CurrentUser?.ProfileImagePath);
        }

        public Brush ProfileImage
        {
            get => _profileImage;
            set
            {
                _profileImage = value;
                OnPropertyChanged(nameof(ProfileImage));
            }
        }

        public string ProfileContent
        {
            get => _profileContent;
            set
            {
                if (_profileContent != value)
                {
                    _profileContent = value;
                    OnPropertyChanged(nameof(ProfileContent));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void UpdateProfileImage(string? imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                _profileImage = new ImageBrush(new BitmapImage(new Uri(imagePath)));
                ProfileContent = null;
            }
            else
            {
                ProfileImage = new SolidColorBrush(Colors.DodgerBlue);
                ProfileContent = UserSession.CurrentUser?.Username?[..1] ?? "V";

                OnPropertyChanged(nameof(ProfileImage));
                OnPropertyChanged(nameof(ProfileContent));
            }
        }
    }
}
