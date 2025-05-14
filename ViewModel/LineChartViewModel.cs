using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.VisualElements;
using System.Globalization;

namespace Expenser.ViewModel
{
    public class LineChartViewModel
    {
        public ISeries[] LineSeries { get; set; }
        public Axis[] XAxis { get; set; }

        public static LineChartViewModel Instance { get;  } = new LineChartViewModel();

        public LineChartViewModel()
        {
            LineSeries =
            [
                new LineSeries<double> { Values = new List<double> { 2, 1, 3, 5, 3, 4, 6, 5, 21, 30, 15, 23 }, Name = "Rent", Fill = null, GeometrySize = 20 },
                new LineSeries<double> { Values = new List<double> { 4, 2, 5, 2, 4, 5, 3, 14, 21, 35, 20, 7 }, Name = "Groceries", Fill = null, GeometrySize = 20 },
                new LineSeries<double> { Values = new List<double> { 5, 15, 17, 23, 8, 19, 7, 3, 14, 25, 30, 21 }, Name = "Utilities", Fill = null, GeometrySize = 20 },
            ];

            List<string> last12Monthes = new List<string>();
            DateTime currentMonth = DateTime.Now;

            for (int i = 11; i >= 0; i--)
            {
                last12Monthes.Add(currentMonth.AddMonths(-i).ToString("MMM", CultureInfo.InvariantCulture));
            }
            XAxis = [
                new Axis {
                    Labels = last12Monthes.ToArray(),
                }
            ];
        }

        public LabelVisual Title { get; set; } = new LabelVisual
        {
            Text = "Monthly Expenses",
            TextSize = 25,
            Padding = new LiveChartsCore.Drawing.Padding(10),
        };
    }
}
