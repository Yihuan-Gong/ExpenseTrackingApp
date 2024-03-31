using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Configuration;
using StreamLibarary;

namespace 記帳
{
    [DisplayName("帳戶")]
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        
        
        private void GroupBy_Clicked(object sender, EventArgs e)
        {
            DateTime startDate = startDateTimePicker.Value;
            DateTime endDate = endDateTimePicker.Value;

            if (startDate > endDate)
            {
                groupByResultTextBox.Text = "開始時間必須早於結束時間！";
                return;
            }

            var records = CsvService.GetRecords(startDate, endDate);

            var result = records
                .GroupBy(x => new
                {
                    Type = typeCheckBox.Checked ? x.Type : null,
                    Content = contentCheckBox.Checked ? x.Content : null,
                    PayMethod = payMethodCheckBox.Checked ? x.PayMethod : null,
                    Property = propertyCheckBox.Checked ? x.Property : null,
                })
                .Select(g => new
                {
                    Type = g.Key.Type,
                    Content = g.Key.Content,
                    PayMethod = g.Key.PayMethod,
                    Property = g.Key.Property,
                    Price = g.Sum(x => int.Parse(x.Price))
                });
            
            string temp = string.Empty;
            foreach (var item in result)
            {
                temp += $"{item.Type}  {item.Content}  {item.PayMethod}  {item.Property}  {item.Price}";
                temp += "\r\n";
            }

            groupByResultTextBox.Text = temp;
        }
    }
}
