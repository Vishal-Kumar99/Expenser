﻿using Expenser.Models;
using Expenser.Pages.ExpenseType;
using Expenser.Pages.NewExpense;
using Expenser.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Expenser.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            if (UserSession.CurrentUser == null)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                mainWindow.MainFrame.Navigate(new LoginPage());
                Window.GetWindow(this)?.Close();
            }
            else
            {
                Func.LoadExpenseType(ExpenseTypeList);
                this.DataContext = new ExpenseListViewModel();
            }
        }

        private void UserProfile_ProfileClicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/UserProfilePage.xaml", UriKind.Relative));
        }

        private void AddExpenseBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateExpenseWindow createExpenseWindow = new CreateExpenseWindow();
            createExpenseWindow.ShowDialog();
        }

        private void ViewExpenseBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportExpenseBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExpenseTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ExpenseTypeWindow();
            Window window = Window.GetWindow(this);
            dialog.Owner = window;
            if (dialog.ShowDialog() == true)
            {
                Func.LoadExpenseType(ExpenseTypeList);
            }
        }

        //private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    var clickedElement = Mouse.DirectlyOver as DependencyObject;

        //    if (!IsDescendant(UserProfile, clickedElement) && !IsDescendant(ProfileMenu, clickedElement))
        //    {
        //        ProfileMenu.Visibility = Visibility.Collapsed;
        //    }
        //}

        //private bool IsDescendant(DependencyObject parent, DependencyObject child)
        //{
        //    if (parent == null || child == null)
        //        return false;

        //    while (child != null)
        //    {
        //        if (child == parent)
        //            return true;
        //        child = VisualTreeHelper.GetParent(child);
        //    }
        //    return false;
        //}

        //private void Calendar_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (ExpenseCalendar.Template.FindName("PART_CalendarItem", ExpenseCalendar) is CalendarItem calendarItem)
        //    {
        //        calendarItem.Loaded += CalendarItem_Loaded;
        //    }
        //}

        //private void CalendarItem_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (sender is CalendarItem calendarItem)
        //    {
        //        foreach (var child in FindVisualChildren<CalendarDayButton>(calendarItem))
        //        {
        //            child.Click += DayButton_Click;
        //        }
        //    }
        //}

        //private void DayButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (sender is CalendarDayButton button && button.DataContext is DateTime date)
        //    {
        //        MessageBox.Show($"Selected date: {date.ToShortDateString()}", "Date Clicked", MessageBoxButton.OK, MessageBoxImage.Information);
        //        //var selectedDate = button.DataContext as DateTime?;
        //        //if (selectedDate.HasValue)
        //        //{
        //        //    var newExpensePage = new NewExpensePage(selectedDate.Value);
        //        //    NavigationService?.Navigate(newExpensePage);
        //        //}
        //    }
        //}

        //private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        //{
        //    if (depObj != null)
        //    {
        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //        {
        //            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
        //            if (child is T t)
        //            {
        //                yield return t;
        //            }
        //            foreach (T childOfChild in FindVisualChildren<T>(child))
        //            {
        //                yield return childOfChild;
        //            }
        //        }
        //    }
        //}
    }
}
