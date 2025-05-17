using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Expenser.ViewModel
{
    public class IncomeSourceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        

        private string _sourceCBox { get; set; }
        private string _amountBox { get; set; }
        private string _statusCBox { get; set; }
        private bool _isInEditMode { get; set; }
        private bool _isLastRow { get; set; }

        public string SourceCBox
        {
            get => _sourceCBox;
            set { _sourceCBox = value; OnPropertyChanged(nameof(SourceCBox)); OnPropertyChanged(nameof(CanAdd)); }
        }
        
        public string AmountBox
        {
            get => _amountBox;
            set { _amountBox = value; OnPropertyChanged(nameof(AmountBox)); OnPropertyChanged(nameof(CanAdd)); }
        }

        public string StatusCBox
        {
            get => _statusCBox;
            set { _statusCBox = value; OnPropertyChanged(nameof(StatusCBox)); OnPropertyChanged(nameof(CanAdd)); }
        }

        public bool IsInEditMode
        {
            get => _isInEditMode;
            set { _isInEditMode = value; OnPropertyChanged(nameof(IsInEditMode)); }
        }

        public bool IsLastRow
        {
            get => _isLastRow;
            set { _isLastRow = value; OnPropertyChanged(nameof(IsLastRow)); OnPropertyChanged(nameof(CanAdd)); }
        }

        public bool CanAdd => string.IsNullOrWhiteSpace(SourceCBox) && string.IsNullOrWhiteSpace(AmountBox) && string.IsNullOrWhiteSpace(StatusCBox) && IsLastRow;

        public ObservableCollection<string> SourceOptions { get; set; }
        public ObservableCollection<string> StatusOptions { get; set; }

        public IncomeSourceViewModel()
        {
            SourceOptions = new ObservableCollection<string> { "Salary", "Business", "Investment", "Other" };
            StatusOptions = new ObservableCollection<string> { "Active", "Inactive" };
        }
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
    
    public class InverseBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value ? Visibility.Visible : Visibility.Collapsed;

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}
