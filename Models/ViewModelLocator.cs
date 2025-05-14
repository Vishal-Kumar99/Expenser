using Expenser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenser.Models
{
    public class ViewModelLocator
    {
        public ProfileViewModel ProfileViewModel => ProfileViewModel.Instance;
        public DonutViewModel DonutViewModel => DonutViewModel.Instance;
        public BarGraphViewModel BarGraphViewModel => BarGraphViewModel.Instance;
        public LineChartViewModel LineChartViewModel => LineChartViewModel.Instance;
    }
}
