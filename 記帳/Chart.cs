using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 記帳
{
    [DisplayName("圖表分析")]
    public partial class Chart : Form
    {
        ChartBuilder chartBuilder;
        SeriesChartType chartType;
        Dictionary<string, SeriesChartType> stringChartTypeMapping;
        List<ExpenceDataType> expenceTypeListForGroupBy;
        Dictionary<string, ExpenceDataType> stringExpenceTypeMapping;

        public Chart()
        {
            InitializeComponent();

            chartBuilder = new ChartBuilder();

            expenceTypeListForGroupBy = new List<ExpenceDataType>();
            stringExpenceTypeMapping = new Dictionary<string, ExpenceDataType>
            {
                { "消費類型", ExpenceDataType.Type },
                { "消費內容", ExpenceDataType.Content },
                { "付款方式", ExpenceDataType.PayMethod },
                { "消費屬性", ExpenceDataType.Property },
            };

            stringChartTypeMapping = new Dictionary<string, SeriesChartType>
            {
                { "支出類型圓餅圖", SeriesChartType.Pie },
                { "每日支出折線圖", SeriesChartType.Column },
                { "每年支出曲線比較", SeriesChartType.Line },
            };
            chartTypeComboBox.Items.Add("支出類型圓餅圖");
            chartTypeComboBox.Items.Add("每日支出折線圖");
            chartTypeComboBox.Items.Add("每年支出曲線比較");

            chart1.Series.Clear();

            //chart1.Series.Add("2023");
            //chart1.Series["2023"].ChartType = SeriesChartType.Line;
            //chart1.Series["2023"].Points.DataBindXY(
            //    new List<int> { 1, 2, 3 },
            //    new List<int> { 4, 5, 6 });

            //chart1.Series.Add("2024");
            //chart1.Series["2024"].ChartType = SeriesChartType.Line;
            //chart1.Series["2024"].Points.DataBindXY(
            //    new List<int> { 1, 2, 3 },
            //    new List<int> { 7, 8, 9 });

        }

        private void ChartTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartType = stringChartTypeMapping[(string)chartTypeComboBox.SelectedItem];

            ChartType backendChartType = FrontendBackendChartTypeMapping.GetBackendChartType(chartType);
            chartBuilder.SetChartType(backendChartType);
        }

        private void ExpenceTypeCheckBoxs_CheckedChanged(object sender, EventArgs e)
        {
            List<CheckBox> expenceTypeCheckBoxs = expenceTypeFlowLayoutPanel.Controls.ToDynamicList<CheckBox>();

            expenceTypeListForGroupBy = new List<ExpenceDataType>();
            foreach (var expenceTypeCheckBox in expenceTypeCheckBoxs)
            {
                if (expenceTypeCheckBox.Checked)
                    expenceTypeListForGroupBy.Add(stringExpenceTypeMapping[expenceTypeCheckBox.Text]);
            }

            chartBuilder.SetGroupByData(expenceTypeListForGroupBy);
        }


        private void AnalyzeBtn_Clicked(object sender, EventArgs e)
        {
            DateTime startDate = startDateTimePicker.Value;
            DateTime endDate = endDateTimePicker.Value;

            chartBuilder.SetDateRange(startDate, endDate);

            ChartData<string, int> pieChartData;
            ChartData<DateTime, int> columnChartData;
            List<ChartData<DateTime, int>> lineChartData;

            chart1.Series.Clear();

            switch (chartType)
            {
                case SeriesChartType.Pie:
                    pieChartData = chartBuilder.Build<string, int>()[0];
                    chart1.Series.Add("Pie");
                    chart1.Series[0].ChartType = chartType;
                    chart1.Series[0].Points.DataBindXY(pieChartData.x, pieChartData.y);
                    for (int i = 0; i < chart1.Series[0].Points.Count; i++)
                    {
                        chart1.Series[0].Points[i].Label = pieChartData.x[i];
                        chart1.Series[0].Points[i].LegendText = pieChartData.labels[i];
                    }
                    break;
                case SeriesChartType.Column:
                    columnChartData = chartBuilder.Build<DateTime, int>()[0];
                    chart1.Series.Add("Expence-Time");
                    chart1.Series[0].ChartType = chartType;
                    chart1.Series[0].Points.DataBindXY(
                        columnChartData.x.Select(x => x.ToString("MMdd")).ToList(),
                        columnChartData.y
                    );
                    break;
                case SeriesChartType.Line:
                    lineChartData = chartBuilder.Build<DateTime, int>();
                    foreach (var item in lineChartData)
                    {
                        chart1.Series.Add(item.seriesName);
                        chart1.Series[item.seriesName].ChartType = chartType;
                        chart1.Series[item.seriesName].Points.DataBindXY(
                            item.x.Select(x => int.Parse(x.ToString("MM"))).ToList(),
                            item.y
                        );
                    }
                    break;
            }


            //chart1.Series[0].Points.DataBindXY(typesForPipeChart, pricesForPipeChart);
            //for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            //{
            //    chart1.Series[0].Points[i].Label = typesForPipeChart[i];
            //    chart1.Series[0].Points[i].LegendText = typesForPipeChart[i] + "#PERCENT";
            //}
        }
    }
}
