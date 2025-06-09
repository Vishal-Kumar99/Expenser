using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace Expenser.ViewModel
{
    public class BarGraphViewModel
    {
        public ISeries[] BarSeries { get; set; }
        public Axis[] XAxis { get; set; }
        public Axis[] YAxis { get; set; }
        public static BarGraphViewModel Instance { get; } = new BarGraphViewModel();

        public BarGraphViewModel()
        {
            BarSeries = new ISeries[]
            {
                new ColumnSeries<double> { Values = [40, 50, 60, 100], Name = "Rent" },
                new ColumnSeries<double> { Values = [30, 40, 50, 70], Name = "Groceries" },
                new ColumnSeries<double> { Values = [20, 30, 40, 80], Name = "Utilities" },
            };

            // Set the labels for the X-axis
            XAxis =
            [
                new Axis {
                    Labels = new[] { "January", "February", "March", "April" },
                    Name = "Months",
                    TextSize = 14
                }
            ];

            YAxis = new Axis[]
            {
                new Axis
                {
                    Labeler = value => $"₹{value}"
                }
            };
        }
    }
}
