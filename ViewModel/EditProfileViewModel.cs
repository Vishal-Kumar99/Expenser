using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Expenser.ViewModel
{
    public class EditProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _userName = string.Empty;
        public string Username
        {
            get => _userName;
            set { _userName = value; OnPropertyChanged(); }
        }

        private string? _name;
        public string? Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string? _email;
        public string? Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        private string? _contact;
        public string? Contact
        {
            get => _contact;
            set { _contact = value; OnPropertyChanged(); }
        }

        private string? _gender;
        public string? Gender
        {
            get => _gender;
            set { _gender = value; OnPropertyChanged(); }
        }

        private string? _preferredCurrency;
        public string? PreferredCurrency
        {
            get => _preferredCurrency;
            set { _preferredCurrency = value; OnPropertyChanged(); }
        }

        private string? _country;
        public string? Country
        {
            get => _country;
            set { _country = value; OnPropertyChanged(); }
        }

        private DateTime _dob;
        public DateTime DOB
        {
            get => _dob;
            set { _dob = value; OnPropertyChanged(); }
        }

        private string? _profileImagePath;
        public string? ProfileImagePath
        {
            get => _profileImagePath;
            set { _profileImagePath = value; OnPropertyChanged(); }
        }

        private string? _coverImagePath;
        public string? CoverImagePath
        {
            get => _coverImagePath;
            set { _coverImagePath = value; OnPropertyChanged(); }
        }

        public void UpdateForm(EditProfileViewModel updated)
        {
            if (updated == null) return;

            if (updated.Username != null) Username = updated.Username;
            if (updated.Name != null) Name = updated.Name;
            if (updated.Email != null) Email = updated.Email;
            if (updated.Contact != null) Contact = updated.Contact;
            if (updated.Gender != null) Gender = updated.Gender;
            if (updated.Country != null) Country = updated.Country;
            if (updated.PreferredCurrency != null) PreferredCurrency = updated.PreferredCurrency;
            DOB = updated.DOB;
            if (updated.ProfileImagePath != null) ProfileImagePath = updated.ProfileImagePath;
            if (updated.CoverImagePath != null) CoverImagePath = updated.CoverImagePath;
        }
    }
}
