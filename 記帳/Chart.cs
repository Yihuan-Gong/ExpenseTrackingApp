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
        ChartDisplayer chartDisplayer;
        Dictionary<string, SeriesChartType> stringChartTypeMapping;
        Dictionary<string, ExpenceDataType> stringExpenceTypeMapping;

        public Chart()
        {
            InitializeComponent();

            chartDisplayer = new ChartDisplayer();

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
                { "每日支出長條圖", SeriesChartType.Column },
                { "每年支出折線比較", SeriesChartType.Line },
            };
            chartTypeComboBox.Items.Add("支出類型圓餅圖");
            chartTypeComboBox.Items.Add("每日支出長條圖");
            chartTypeComboBox.Items.Add("每年支出折線比較");

            chart1.Series.Clear();
        }

        private void AnalyzeBtn_Clicked(object sender, EventArgs e)
        {
            ChartUserInput chartUserInput = PackUserInputs();

            chartDisplayer.Display(chartUserInput, chart1);
        }

        private ChartUserInput PackUserInputs()
        {
            List<CheckBox> expenceTypeCheckBoxs = expenceTypeFlowLayoutPanel.Controls.ToDynamicList<CheckBox>();
            List<ExpenceDataType> expenceTypeListForGroupBy = new List<ExpenceDataType>();
            foreach (CheckBox expenceTypeCheckBox in expenceTypeCheckBoxs)
            {
                if (expenceTypeCheckBox.Checked)
                    expenceTypeListForGroupBy.Add(stringExpenceTypeMapping[expenceTypeCheckBox.Text]);
            }

            var userInput = new ChartUserInput
            {
                ChartType = stringChartTypeMapping[(string)chartTypeComboBox.SelectedItem],
                ExpenceDataTypes = expenceTypeListForGroupBy,
                StartDate = startDateTimePicker.Value,
                EndDate = endDateTimePicker.Value
            };
            return userInput;
        }
    }
}
