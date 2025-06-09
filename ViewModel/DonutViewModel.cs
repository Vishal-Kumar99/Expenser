using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace Expenser.ViewModel
{
    public class DonutViewModel
    {
        public ISeries[] DonutSeries { get; set; }
        public static DonutViewModel Instance { get; } = new DonutViewModel();


        public DonutViewModel()
        {
            DonutSeries =
            [
                new PieSeries<double> { Values = new List<double> { 40}, Name = "Rent"},
                new PieSeries<double> { Values = new List<double> { 40}, Name = "Groceries"},
                new PieSeries<double> { Values = new List<double> { 40}, Name = "Utilities"},
            ];
        }
    }
}
