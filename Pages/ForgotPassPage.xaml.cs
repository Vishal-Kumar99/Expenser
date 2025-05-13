using Expenser.Models;
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
    /// Interaction logic for ForgotPassPage.xaml
    /// </summary>
    public partial class ForgotPassPage : Page
    {
        private int FirstNum, SecondNum;
        public ForgotPassPage()
        {
            InitializeComponent();

            GeneratedRandomNumbers();

            ResetPassBtn.Background = new SolidColorBrush(Colors.LightGray);
            ResetPassBtn.IsEnabled = false;
        }

        private void LoginLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/LoginPage.xaml", UriKind.Relative));
        }

        private void ResetPassBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTxt.Text;
            string password = NewPassTxt.Text;

            if (string.IsNullOrWhiteSpace(UsernameTxt.Text) || string.IsNullOrWhiteSpace(NewPassTxt.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            using (var dbContext = new ApplicationDbContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    MessageBox.Show("User not found.");
                    GeneratedRandomNumbers();
                    AnswerTxt.Text = string.Empty;
                    AnswerTxt.IsEnabled = true;
                    ResetPassBtn.Background = new SolidColorBrush(Colors.LightGray);
                    ResetPassBtn.IsEnabled = false;
                    return;
                }
                // Hash the new password
                string hashedPassword = Func.HashPassword(password);
                user.Password = hashedPassword;
                dbContext.SaveChanges();
            }
            NavigationService.Navigate(new Uri("Pages/LoginPage.xaml", UriKind.Relative));
        }

        private void VerifyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyAnswer())
            {
                ResetPassBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6200EE"));
                ResetPassBtn.IsEnabled = true;
            }
        }

        private void GeneratedRandomNumbers()
        {
            int FirstRandom = GenerateRandomNum();
            FirstNumLabel.Text = FirstRandom.ToString();

            int SecondRandom = GenerateRandomNum();
            SecondNumLabel.Text = SecondRandom.ToString();
        }

        private bool VerifyAnswer()
        {
            FirstNum = int.Parse(FirstNumLabel.Text);
            SecondNum = int.Parse(SecondNumLabel.Text);

            int Sum = FirstNum + SecondNum;

            int userAnswer;
            if (!string.IsNullOrWhiteSpace(AnswerTxt.Text) && int.TryParse(AnswerTxt.Text, out userAnswer) && userAnswer == Sum)
            {
                AnswerLabel.Text = Sum.ToString();
                AnswerTxt.IsEnabled = false;
                return true;
            }
            else
            {
                MessageBox.Show("Incorrect answer. Please try again.");
                return false;
            }
        }

        private int GenerateRandomNum()
        {
            var random = new Random();
            int randomNum = random.Next(1, 100);
            return randomNum;
        }
    }
}
