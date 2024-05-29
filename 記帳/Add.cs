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
        public event EventHandler RecordEdited;

        private OpenFileDialog openFileDialogImage1, openFileDialogImage2;
        private bool bined = false;

        public Add()
        {
            InitializeComponent();

            typeComboBox.DataSource = AppData.typeList;
            typeComboBox.DisplayMember = "Key";
            typeComboBox.ValueMember = "Value";

            ResetPictureBoxAndOpenFileDialog();
        }


        public void SetBindingRecord(RecordModel record)
        {
            // Input: record從Notebook Form裡面的List<RecordModel>要被編輯的RecordModel來
            // 這裡要讓record和Add Form裡面的Textbox、Combobox等等UI連動
            // 但目前DateTime、Image1、Image2無法和record連動

            bined = true;

            var updateMode = DataSourceUpdateMode.OnPropertyChanged;
            //dateTimeBox.DataBindings.Add("Value", record, nameof(record.DateTime), false, updateMode); // ?
            priceBox.DataBindings.Add("Text", record, nameof(record.Price), false, updateMode);
            typeComboBox.DataBindings.Add("Text", record, nameof(record.Type), false, updateMode);
            containComboBox.DataBindings.Add("Text", record, nameof(record.Content), false, updateMode);
            payMethodComboBox.DataBindings.Add("Text", record, nameof(record.PayMethod), false, updateMode);
            propertyComboBox.DataBindings.Add("Text", record, nameof(record.Property), false, updateMode);
            //pictureBox1.DataBindings.Add("Image", record, nameof(record.Image1), false, updateMode); // ?
            //pictureBox2.DataBindings.Add("Image", record, nameof(record.Image2), false, updateMode); // ?
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



        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (bined)
            {
                // AddForm編輯頁面編輯完成後，也會觸發RecordEdited事件，
                // 提醒Notebook去將已經連動更新完成的List<RecordModel> 資料放到UI
                RecordEdited.Invoke(this, null);
                return;
            }

            var record = new RecordModel
            {
                DateTime = dateTimeBox.Value.ToString("yyyy-MM-dd"),
                Price = priceBox.Text,
                Type = typeComboBox.Text,
                Content = containComboBox.Text,
                PayMethod = payMethodComboBox.Text,
                Property = propertyComboBox.Text,
                Image1 = CopyImageToServer(openFileDialogImage1),
                Image2 = CopyImageToServer(openFileDialogImage2),
            };

            CsvHelper.WriteLineCSV(GetFilePath(FileType.Csv), record);
            ResetPictureBoxAndOpenFileDialog();

            priceBox.Text = string.Empty;
            typeComboBox.SelectedIndex = 0;
            containComboBox.SelectedIndex = 0;
        }


        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = ((KeyValuePair<string, string>)typeComboBox.SelectedItem).Key;
            containComboBox.DataSource = AppData.typeDictionary[selectedType];
            containComboBox.DisplayMember = "key";
            containComboBox.ValueMember = "value";
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
            pictureBox1.Image = Image.FromFile($"{ConfigurationManager.AppSettings["serverDir"]}\\Images\\upload.png");
            pictureBox2.Image = Image.FromFile($"{ConfigurationManager.AppSettings["serverDir"]}\\Images\\upload.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            openFileDialogImage1 = new OpenFileDialog();
            openFileDialogImage2 = new OpenFileDialog();
        }
    }
}
