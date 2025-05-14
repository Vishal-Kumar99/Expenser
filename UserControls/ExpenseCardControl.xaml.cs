using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Expenser.UserControls
{
    /// <summary>
    /// Interaction logic for ExpenseCardControl.xaml
    /// </summary>
    public partial class ExpenseCardControl : UserControl
    {
        public ExpenseCardControl()
        {
            InitializeComponent();
            //DataContext = this;
        }

        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register(nameof(BackgroundColor), typeof(Brush), typeof(ExpenseCardControl), new PropertyMetadata(Brushes.IndianRed));

        public static readonly DependencyProperty ForegroundColorProperty =
            DependencyProperty.Register(nameof(ForegroundColor), typeof(Brush), typeof(ExpenseCardControl), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty MonthBackgroundProperty =
            DependencyProperty.Register(nameof(MonthBackground), typeof(Brush), typeof(ExpenseCardControl), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty MonthForegroundProperty =
            DependencyProperty.Register(nameof(MonthForeground), typeof(Brush), typeof(ExpenseCardControl), new PropertyMetadata(Brushes.IndianRed));

        public static readonly DependencyProperty ExpenseTitleProperty =
            DependencyProperty.Register(nameof(ExpenseTitle), typeof(string), typeof(ExpenseCardControl), new PropertyMetadata("Card Title"));

        public static readonly DependencyProperty TotalExpenseProperty =
            DependencyProperty.Register(nameof(TotalExpense), typeof(string), typeof(ExpenseCardControl), new PropertyMetadata("₹ 0.00"));

        public static readonly DependencyProperty ExpenseMonthProperty =
            DependencyProperty.Register(nameof(ExpenseMonth), typeof(string), typeof(ExpenseCardControl), new PropertyMetadata("Feb"));

        public Brush BackgroundColor
        {
            get => (Brush)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public Brush ForegroundColor
        {
            get => (Brush)GetValue(ForegroundColorProperty);
            set => SetValue(ForegroundColorProperty, value);
        }

        public Brush MonthBackground
        {
            get => (Brush)GetValue(MonthBackgroundProperty);
            set => SetValue(MonthBackgroundProperty, value);
        }

        public Brush MonthForeground
        {
            get => (Brush)GetValue(MonthForegroundProperty);
            set => SetValue(MonthForegroundProperty, value);
        }

        public string ExpenseTitle
        {
            get => (string)GetValue(ExpenseTitleProperty);
            set => SetValue(ExpenseTitleProperty, value);
        }

        public string TotalExpense
        {
            get => (string)GetValue(TotalExpenseProperty);
            set => SetValue(TotalExpenseProperty, value);
        }

        public string ExpenseMonth
        {
            get => (string)GetValue(ExpenseMonthProperty);
            set => SetValue(ExpenseMonthProperty, value);
        }
    }
}
