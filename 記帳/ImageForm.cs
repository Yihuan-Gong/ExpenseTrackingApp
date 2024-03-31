using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 記帳
{
    public partial class ImageForm : Form
    {
        public ImageForm()
        {
            InitializeComponent();
        }


        public void SetImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath)) return;

            Image image = Image.FromFile(imagePath);
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
