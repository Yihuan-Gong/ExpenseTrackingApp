using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 記帳
{
    public class RecordModel
    {
        [DisplayName("日期")]
        public string DateTime { get; set; }

        [DisplayName("金額")]
        public string Price { get; set; }

        [DisplayName("消費類型")]
        public string Type { get; set; }

        [DisplayName("消費內容")]
        public string Content { get; set; }

        [DisplayName("付款方式")]
        public string PayMethod { get; set; }

        [DisplayName("消費屬性")]
        public string Property { get; set; }

        [DisplayName("發票/收據1")]
        public string Image1 { get; set; }

        [DisplayName("發票/收據2")]
        public string Image2 { get; set; }
    }
}
