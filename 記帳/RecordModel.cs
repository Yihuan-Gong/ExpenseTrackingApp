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
        private string dateTime;
        private string price;
        private string type;
        private string content;
        private string paymethod;
        private string property;
        private string image1;
        private string image2;


        [DisplayName("日期")]
        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; OnPropertyChanged(nameof(dateTime)); }
        }

        [DisplayName("金額")]
        public string Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(nameof(price)); }
        }

        [DisplayName("消費類型")]
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(nameof(Type)); }
        }

        [DisplayName("消費內容")]
        public string Content
        {
            get { return content; }
            set { content = value; OnPropertyChanged(nameof(Content)); }
        }

        [DisplayName("付款方式")]
        public string PayMethod
        {
            get { return paymethod; }
            set { paymethod = value; OnPropertyChanged(nameof(PayMethod)); }
        }

        [DisplayName("消費屬性")]
        public string Property
        {
            get { return property; }
            set { property = value; OnPropertyChanged(nameof(Property)); }
        }

        [DisplayName("發票/收據1")]
        public string Image1
        {
            get { return image1; }
            set { image1 = value; OnPropertyChanged(nameof(Image1)); }
        }

        [DisplayName("發票/收據2")]
        public string Image2
        {
            get { return image2; }
            set { image2 = value; OnPropertyChanged(nameof(Image2)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
