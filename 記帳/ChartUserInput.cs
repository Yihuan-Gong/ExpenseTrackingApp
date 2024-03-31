using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace 記帳
{
    internal class ChartUserInput
    {
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public SeriesChartType ChartType { set; get; }
        public IEnumerable<ExpenceDataType> ExpenceDataTypes { set; get; }
    }
}
