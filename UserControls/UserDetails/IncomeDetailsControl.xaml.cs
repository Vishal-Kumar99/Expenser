using Expenser.Models;
using Expenser.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Expenser.UserControls.UserDetails
{
    /// <summary>
    /// Interaction logic for IncomeDetailsControl.xaml
    /// </summary>
    public partial class IncomeDetailsControl : UserControl
    {
        private ObservableCollection<IncomeSourceViewModel> _items;

        public IncomeDetailsControl()
        {
            InitializeComponent();

            _items = new ObservableCollection<IncomeSourceViewModel>();
            LoadInitialData();
            IncomeSourceListView.ItemsSource = _items;
        }

        private void LoadInitialData()
        {
            _items.Add(new IncomeSourceViewModel
            {
                SourceCBox = "Salary",
                AmountBox = "5000",
                StatusCBox = "Active"
            });
            SetLastRow();
        }

        private void SetLastRow()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].IsLastRow = (i == _items.Count - 1);
            }
        }

        private void RemoveTrailingEmptyRow()
        {
            var emptyItems = _items.Where(item =>
                    string.IsNullOrWhiteSpace(item.SourceCBox) &&
                    string.IsNullOrWhiteSpace(item.AmountBox) &&
                    string.IsNullOrWhiteSpace(item.StatusCBox)).ToList();

            foreach (var item in emptyItems)
            {
                _items.Remove(item);
            }
        }

        private void AddRowBtn_Click(object sender, RoutedEventArgs e)
        {
            _items.Add(new IncomeSourceViewModel { IsInEditMode = true });
            SetLastRow();
        }

        private void DeleteRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is IncomeSourceViewModel row)
            {
                _items.Remove(row);
                SetLastRow();
            }
        }

        private void EditListBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _items)
                item.IsInEditMode = true;

            if (!_items.Any(item => 
                string.IsNullOrWhiteSpace(item.SourceCBox) &&
                string.IsNullOrWhiteSpace(item.AmountBox) &&
                string.IsNullOrWhiteSpace(item.StatusCBox)))
            {
                _items.Add(new IncomeSourceViewModel { IsInEditMode = true });
            }

            SetLastRow();

            EditListBtn.Visibility = Visibility.Collapsed;
            SaveIncomeBtn.Visibility = Visibility.Visible;
            CancelBtn.Visibility = Visibility.Visible;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            //for (int i = _items.Count - 1; i >= 0; i--)
            //{
            //    var item = _items[i];
            //    if (string.IsNullOrWhiteSpace(item.SourceCBox) && string.IsNullOrWhiteSpace(item.AmountBox) && string.IsNullOrWhiteSpace(item.StatusCBox))
            //    {
            //        _items.RemoveAt(i);
            //    }
            //}

            RemoveTrailingEmptyRow();

            foreach (var item in _items)
                item.IsInEditMode = false;

            SaveIncomeBtn.Visibility = Visibility.Collapsed;
            CancelBtn.Visibility = Visibility.Collapsed;
            EditListBtn.Visibility = Visibility.Visible;

            SetLastRow();
        }

        private void SaveIncomeBtn_Click(object sender, RoutedEventArgs e)
        {
            RemoveTrailingEmptyRow();

            foreach (var item in _items)
                item.IsInEditMode = false;

            SaveIncomeBtn.Visibility = Visibility.Collapsed;
            CancelBtn.Visibility = Visibility.Collapsed;
            EditListBtn.Visibility = Visibility.Visible;

            SetLastRow();
        }

        private void IncomeSourceListView_Loaded(object sender, RoutedEventArgs e)
        {
            SetListViewColumnWidth();
        }

        private void IncomeSourceListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetListViewColumnWidth();
        }

        private void SetListViewColumnWidth()
        {
            if (IncomeSourceListView.View is GridView gridView && gridView.Columns.Count > 0)
            {
                double totalWidth = IncomeSourceListView.ActualWidth;

                if (SystemParameters.VerticalScrollBarWidth > 0)
                {
                    totalWidth -= SystemParameters.VerticalScrollBarWidth;
                }

                double columnWidth = totalWidth / gridView.Columns.Count;

                foreach (var column in gridView.Columns)
                {
                    column.Width = columnWidth;
                }
            }
        }
    }
}
