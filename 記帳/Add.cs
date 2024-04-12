using StreamLibarary;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 記帳;
using System.Configuration;

namespace 記帳
{
    [DisplayName("記一筆")]
    public partial class Add : Form
    {
        private OpenFileDialog openFileDialogImage1, openFileDialogImage2;

        public Add()
        {
            InitializeComponent();

            TypeComboBox.DataSource = AppData.typeList;
            TypeComboBox.DisplayMember = "Key";
            TypeComboBox.ValueMember = "Value";

            ResetPictureBoxAndOpenFileDialog();
        }


        private void UploadImageClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = null;
            var pictureBox = (PictureBox)sender;

            switch (pictureBox.Name)
            {
                case "PictureBox1":
                    openFileDialog = openFileDialogImage1;
                    break;
                case "PictureBox2":
                    openFileDialog = openFileDialogImage2;
                    break;
            }

            openFileDialog.Filter = "圖片檔|*.png;*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.ImageLocation = openFileDialog.FileName;

                Console.WriteLine(openFileDialog.FileName);
            }
        }



        private void AddNewBtn_Click(object sender, EventArgs e)
        {
            var record = new RecordModel
            {
                DateTime = dateTimeBox.Value.ToString("yyyy-MM-dd"),
                Price = PriceBox.Text,
                Type = TypeComboBox.Text,
                Content = ContainComboBox.Text,
                PayMethod = PayMethodComboBox.Text,
                Property = PropertyComboBox.Text,
                Image1 = CopyImageToServer(openFileDialogImage1),
                Image2 = CopyImageToServer(openFileDialogImage2),
            };

            CsvHelper.WriteLineCSV(GetFilePath(FileType.Csv), record);
            ResetPictureBoxAndOpenFileDialog();

            PriceBox.Text = string.Empty;
            TypeComboBox.SelectedIndex = 0;
            ContainComboBox.SelectedIndex = 0;
        }


        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = ((KeyValuePair<string, string>)TypeComboBox.SelectedItem).Key;
            ContainComboBox.DataSource = AppData.typeDictionary[selectedType];
            ContainComboBox.DisplayMember = "key";
            ContainComboBox.ValueMember = "value";
        }

        // Input: 開啟影像的OpenFileDialog
        // Output: 影像複製到server後，在server的路徑
        private string CopyImageToServer(OpenFileDialog openFileDialog)
        {
            string path = openFileDialog.FileName;

            if (string.IsNullOrEmpty(path))
                return string.Empty;

            string imageServerPath = GetFilePath(FileType.Image);
            string imageServerDir = Path.GetDirectoryName(imageServerPath);

            if (!Directory.Exists(imageServerDir))
                Directory.CreateDirectory(imageServerDir);

            File.Copy(path, imageServerPath, true);
            return imageServerPath;
        }

        private string GetFilePath(FileType fileType)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string serverDir = ConfigurationManager.AppSettings["serverDir"];
            string path = string.Empty;

            switch (fileType)
            {
                case FileType.Csv:
                    path = $"{serverDir}\\Csv\\{date}.csv";
                    break;
                case FileType.Image:
                    path = $"{serverDir}\\Images\\{date}\\{Guid.NewGuid()}.png";
                    break;
            }

            return path;
        }

        private void ResetPictureBoxAndOpenFileDialog()
        {
            PictureBox1.Image = Image.FromFile($"{ConfigurationManager.AppSettings["serverDir"]}\\Images\\upload.png");
            PictureBox2.Image = Image.FromFile($"{ConfigurationManager.AppSettings["serverDir"]}\\Images\\upload.png");
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            openFileDialogImage1 = new OpenFileDialog();
            openFileDialogImage2 = new OpenFileDialog();
        }
    }
}
