using Expenser.Models;
using Expenser.ViewModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Expenser.UserControls.UserDetails
{
    /// <summary>
    /// Interaction logic for IncomeDetailsControl.xaml
    /// </summary>
    public partial class IncomeDetailsControl : UserControl
    {
        private IncomeSourceViewModel _viewModel;

        public IncomeDetailsControl()
        {
            InitializeComponent();

            _viewModel = new IncomeSourceViewModel();
            this.DataContext = _viewModel;

            _viewModel.UpdateTotalAmount();
            LoadInitialData();

            IncomeSourceListView.ItemsSource = _viewModel.Items;
        }

        private void LoadInitialData()
        {
            using (var context = new ApplicationDbContext())
            {
                _viewModel.Items.Clear();
                var user = UserSession.CurrentUser;
                if (user == null) return;

                var incomeSources = context.Incomes.Where(i => i.UserId == user.Id).ToList();

                foreach (var record in incomeSources)
                {
                    _viewModel.Items.Add(new IncomeItemViewModel
                    {
                        SourceCBox = record.Source,
                        AmountBox = record.Amount.ToString("F2", CultureInfo.InvariantCulture),
                        StatusCBox = record.Status,
                        IsInEditMode = false,
                        IsLastRow = false
                    });
                }
            }
            SetLastRow();
        }

        private void SetLastRow()
        {
            for (int i = 0; i < _viewModel.Items.Count; i++)
            {
                _viewModel.Items[i].IsLastRow = (i == _viewModel.Items.Count - 1);
            }
        }

        private void RemoveTrailingEmptyRow()
        {
            var emptyItems = _viewModel.Items.Where(item =>
                    string.IsNullOrWhiteSpace(item.SourceCBox) &&
                    string.IsNullOrWhiteSpace(item.AmountBox) &&
                    string.IsNullOrWhiteSpace(item.StatusCBox)).ToList();

            foreach (var item in emptyItems)
            {
                _viewModel.Items.Remove(item);
            }
        }

        private void AddRowBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Items.Add(new IncomeItemViewModel { IsInEditMode = true });
            SetLastRow();
        }

        private void DeleteRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is IncomeItemViewModel row)
            {
                using (var context = new ApplicationDbContext())
                {
                    var user = UserSession.CurrentUser;
                    if (user == null) return;
                    var incomeToDelete = context.Incomes.FirstOrDefault(i => i.UserId == user.Id && i.Source == row.SourceCBox);
                    if (incomeToDelete != null)
                    {
                        context.Incomes.Remove(incomeToDelete);
                        _viewModel.Items.Remove(row);
                        context.SaveChanges();
                        _viewModel.UpdateTotalAmount();
                        MessageBox.Show("Income source deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                SetLastRow();
            }
        }

        private void EditListBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _viewModel.Items)
                item.IsInEditMode = true;

            if (!_viewModel.Items.Any(item =>
                string.IsNullOrWhiteSpace(item.SourceCBox) &&
                string.IsNullOrWhiteSpace(item.AmountBox) &&
                string.IsNullOrWhiteSpace(item.StatusCBox)))
            {
                _viewModel.Items.Add(new IncomeItemViewModel { IsInEditMode = true });
            }

            SetLastRow();

            EditListBtn.Visibility = Visibility.Collapsed;
            SaveIncomeBtn.Visibility = Visibility.Visible;
            CancelBtn.Visibility = Visibility.Visible;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            RemoveTrailingEmptyRow();

            foreach (var item in _viewModel.Items)
                item.IsInEditMode = false;

            SaveIncomeBtn.Visibility = Visibility.Collapsed;
            CancelBtn.Visibility = Visibility.Collapsed;
            EditListBtn.Visibility = Visibility.Visible;

            SetLastRow();
        }

        private void SaveIncomeBtn_Click(object sender, RoutedEventArgs e)
        {
            RemoveTrailingEmptyRow();

            SaveIncomeDetails();

            foreach (var item in _viewModel.Items)
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

        private void SaveIncomeDetails()
        {
            using (var context = new ApplicationDbContext())
            {
                var user = UserSession.CurrentUser;

                if (user == null) return;

                foreach (var item in _viewModel.Items)
                {
                    var source = item.SourceCBox?.Trim();
                    var status = item.StatusCBox?.Trim();
                    var amountText = item.AmountBox?.Trim();

                    if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(status) || string.IsNullOrWhiteSpace(amountText) || !decimal.TryParse(amountText, out var amount))
                        continue;

                    var today = DateTime.Now.Date;

                    var existingSource = context.Incomes.FirstOrDefault(i => i.UserId == user.Id && i.Source == item.SourceCBox);

                    if (existingSource != null)
                    {
                        if (existingSource.Amount != amount || existingSource.Status != item.StatusCBox)
                        {
                            existingSource.Amount = amount;
                            existingSource.Status = item.StatusCBox;
                            context.Incomes.Update(existingSource);

                        }
                    }
                    else
                    {
                        var incomeSource = new Income
                        {
                            UserId = user.Id,
                            Source = source,
                            Amount = amount,
                            Status = status,
                            Date = DateTime.Now,
                        };

                        context.Incomes.Add(incomeSource);
                    }
                }
                context.SaveChanges();

                _viewModel.UpdateTotalAmount();

                MessageBox.Show("Income sources added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
