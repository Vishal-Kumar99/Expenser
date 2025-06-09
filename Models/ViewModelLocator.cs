using Expenser.ViewModel;

namespace Expenser.Models
{
    public class ViewModelLocator
    {
        public DonutViewModel DonutViewModel => DonutViewModel.Instance;
        public BarGraphViewModel BarGraphViewModel => BarGraphViewModel.Instance;
        public LineChartViewModel LineChartViewModel => LineChartViewModel.Instance;
    }
}
