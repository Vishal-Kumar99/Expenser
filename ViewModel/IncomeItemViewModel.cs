using Expenser.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Expenser.ViewModel
{
    public class IncomeItemViewModel : INotifyPropertyChanged
    {
        private IncomeSourceViewModel _viewModel;
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string _sourceCBox;
        private string _amountBox;
        private string _statusCBox;
        private bool _isInEditMode;
        private bool _isLastRow;

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

        public IncomeItemViewModel()
        {
            _sourceCBox = string.Empty;
            _statusCBox = string.Empty;
            _isInEditMode = false;
            _isLastRow = false;

            _viewModel = new IncomeSourceViewModel();

            LoadData();
        }


        public ObservableCollection<string> SourceOptions { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> StatusOptions { get; set; } = new ObservableCollection<string>();

        public void LoadData()
        {
            var user = UserSession.CurrentUser;
            if (user == null) return;

            using var context = new ApplicationDbContext();

            var sources = context.Incomes
                    .Where(i => i.UserId == user.Id)
                    .Select(i => i.Source)
                    .Distinct()
                    .ToList();

            var statuses = context.Incomes
                .Where(i => i.UserId == user.Id)
                .Select(i => i.Status)
                .Distinct()
                .ToList();

            if (sources != null && sources.Any())
            {
                foreach (var source in sources)
                {
                    if (!string.IsNullOrWhiteSpace(source))
                        SourceOptions.Add(source);
                }
            }

            if (statuses != null && statuses.Any())
            {
                foreach (var status in statuses)
                {
                    if (!string.IsNullOrWhiteSpace(status))
                        StatusOptions.Add(status);
                }
            }

            _viewModel.UpdateTotalAmount();
        }
    }
}
