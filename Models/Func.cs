using System.Text;
using System.Security.Cryptography;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using Expenser.ViewModel;


namespace Expenser.Models
{
    public static class Func
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static void LoadExpenseType(params ItemsControl[] controls)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var items = dbContext.ExpenseTypes.ToList();

                foreach (var control in controls)
                {
                    control.ItemsSource = items;

                    if (control is ComboBox comboBox)
                    {
                        comboBox.DisplayMemberPath = "Type";
                        comboBox.SelectedValuePath = "Id";
                        comboBox.SelectedIndex = -1;
                    }
                    else if (control is ListBox listBox)
                    {
                        listBox.DisplayMemberPath = "Type";
                    }
                }
            }
        }

        public static void LoadUserDetails()
        {
            var currentUser = UserSession.CurrentUser;

            if (currentUser == null)
            {
                return;
            }

            using (var dbContext = new ApplicationDbContext())
            {

                var user = dbContext.Users
                        .AsNoTracking()
                        .FirstOrDefault(u => u.Username == currentUser.Username);

                if (user != null)
                {
                    UserSession.CurrentUser = user;
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
        }

        public static EditProfileViewModel GetUserDetails()
        {
            var currentUser = UserSession.CurrentUser;

            if (currentUser != null)
            {
                return new EditProfileViewModel
                {
                    Username = currentUser.Username,
                    Name = currentUser.Name,
                    Email = currentUser.Email,
                    Contact = currentUser.Contact,
                    Gender = currentUser.Gender,
                    PreferredCurrency = currentUser.PreferredCurrency,
                    Country = currentUser.Country,
                    DOB = currentUser.DOB,
                    ProfileImagePath = currentUser.ProfileImagePath,
                    CoverImagePath = currentUser.CoverImagePath
                };
            }
            else
            {
                MessageBox.Show("User not found.");
                return null;
            }
        }

        public static void SaveUserDetails(EditProfileViewModel editProfileView)
        {
            if (editProfileView == null)
            {
                MessageBox.Show("Please fill in the fields.");
                return;
            }

            using (var dbContext = new ApplicationDbContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Username == editProfileView.Username);

                if (user == null)
                {
                    MessageBox.Show("User not found.");
                    return;
                }

                bool isModified = false;

                if (user.Name != editProfileView.Name) { user.Name = editProfileView.Name; isModified = true; }
                if (user.Gender != editProfileView.Gender) { user.Gender = editProfileView.Gender; isModified = true; }
                if (user.Country != editProfileView.Country) { user.Country = editProfileView.Country; isModified = true; }
                if (user.PreferredCurrency != editProfileView.PreferredCurrency) { user.PreferredCurrency = editProfileView.PreferredCurrency; isModified = true; }
                if (user.DOB != editProfileView.DOB) { user.DOB = editProfileView.DOB; isModified = true; }
                if (user.Contact != editProfileView.Contact) { user.Contact = editProfileView.Contact; isModified = true; }
                if (user.Email != editProfileView.Email) { user.Email = editProfileView.Email; isModified = true; }

                if (isModified)
                {
                    user.ModifiedDate = DateTime.Now;
                    dbContext.SaveChanges();
                    UserSession.CurrentUser = user; // Update the current user session
                    MessageBox.Show("User details updated successfully.");
                }
                else
                {
                    MessageBox.Show("No changes made to user details.");
                }
            }
        }
    }

    //public class UserDto
    //{
    //    public required string Username { get; set; }
    //    public string? Name { get; set; }
    //    public string? Email { get; set; }
    //    public string? Contact { get; set; }
    //    public string? Gender { get; set; }
    //    public string? PreferredCurrency { get; set; }
    //    public string? Country { get; set; }
    //    public DateTime DOB { get; set; }
    //    public string? ProfileImagePath { get; set; }
    //    public string? CoverImagePath { get; set; }
    //}
}
