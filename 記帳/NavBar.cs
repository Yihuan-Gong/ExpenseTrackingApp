using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 記帳
{
    public partial class NavBar : UserControl
    {
        public static Form form;

        public NavBar()
        {
            InitializeComponent();
        }

        private void NavBarButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string formName = button.Text;

            SingletonForm.GetInstance(formName).Show();
        }
    }
}
