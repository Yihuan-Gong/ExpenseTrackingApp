using StreamLibarary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 記帳
{
    [DisplayName("記事本")]
    public partial class Notebook : Form
    {
        public static List<RecordModel> Records { get; private set; }
        ImageService imageService;
        DateTime seletedDate;
        const int TYPE_INDEX = 2;
        const int CONTENT_INDEX = 3;
        const int IMAGE1_COL = 8;
        const int IMAGE2_COL = 9;
        const int EDIT_BTN_COL = 10;
        const int DELETE_BTN_COL = 11;

        public Notebook()
        {
            InitializeComponent();

            Records = new List<RecordModel>();
            DataGridView1.DataError += DataGridView1_DataError;
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            this.DebounceHandler(() =>
            {

                seletedDate = DateTimePicker1.Value;
                Records = CsvService.GetRecords(seletedDate);

                imageService = new ImageService(Records);
                LoadDataGridView();

                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                DataGridView1.RowHeadersVisible = false;
                DataGridView1.BackgroundColor = Color.White;
            });
        }


        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case IMAGE1_COL:
                case IMAGE2_COL:
                    ImageCellClick(sender, e);
                    break;

                case DELETE_BTN_COL:
                    DeleteBtnCellClick(sender, e);
                    break;
            }
        }


        private void ImageCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != IMAGE1_COL && e.ColumnIndex != IMAGE2_COL)
                return;

            int imageNum = (e.ColumnIndex == IMAGE1_COL) ? 1 : 2;
            string imagePath = imageService.GetImagePath(e.RowIndex, imageNum);

            if (!string.IsNullOrEmpty(imagePath))
            {
                var imageForm = ImageSingletonForm.GetImageForm();
                imageForm.SetImage(imagePath);
                imageForm.Show();
            }
        }

        private void DeleteBtnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != DELETE_BTN_COL) return;

            Records.RemoveAt(e.RowIndex);
            CsvService.WriteRecordsToCsv(seletedDate, Records);
            LoadDataGridView();
        }


        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string propertyToModify = DataGridView1.Columns[e.ColumnIndex].DataPropertyName;
            var cellValue = DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (cellValue == null) return;

            if (e.ColumnIndex == TYPE_INDEX)
                DataGridView1_TypeColumnEdited(e.RowIndex);
            else
            {
                string value = cellValue.ToString();
                Records[e.RowIndex].GetType().GetProperty(propertyToModify)
                    .SetValue(Records[e.RowIndex], value);
            }

            CsvService.WriteRecordsToCsv(seletedDate, Records);
        }


        private void DataGridView1_TypeColumnEdited(int rowIndex)
        {
            string currentType = DataGridView1.Rows[rowIndex].Cells[TYPE_INDEX].Value.ToString();
            DataGridViewComboBoxCell contentCell
                = DataGridView1.Rows[rowIndex].Cells[CONTENT_INDEX] as DataGridViewComboBoxCell;

            contentCell.Value = null;
            contentCell.DataSource = AppData.typeDictionary[currentType];
            contentCell.Value = AppData.typeDictionary[currentType][0].Key;

            Records[rowIndex].GetType().GetProperty("Type")
                .SetValue(Records[rowIndex], currentType);
            Records[rowIndex].GetType().GetProperty("Content")
                .SetValue(Records[rowIndex], contentCell.Value.ToString());
        }

        private void LoadDataGridView()
        {
            DataGridView1.Columns.Clear();
            DataGridView1.DataSource = null;
            GC.Collect();

            DataGridView1.DataSource = Records;
            DataGridView1.Columns.RemoveAt(DataGridView1.Columns["Type"].Index);
            DataGridView1.Columns.RemoveAt(DataGridView1.Columns["Content"].Index);

            // 創建消費類型下拉選單
            var typeComboBoxColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "消費類型",
                DataPropertyName = "Type",
                DataSource = AppData.typeList,
                DisplayMember = "key",
                ValueMember = "value",
            };

            // 創建消費內容下拉選單
            var contentComboBoxColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "消費內容",
                DataPropertyName = "Content",
                DisplayMember = "key",
                ValueMember = "value",
            };

            // 插入Type col = 2、Content col = 3
            DataGridView1.Columns.Insert(TYPE_INDEX, typeComboBoxColumn);
            DataGridView1.Columns.Insert(CONTENT_INDEX, contentComboBoxColumn);

            for (int i = 0; i < DataGridView1.RowCount; i++)
            {
                DataGridView1.Rows[i].Cells[TYPE_INDEX].Value = Records[i].Type;
                (DataGridView1.Rows[i].Cells[CONTENT_INDEX] as DataGridViewComboBoxCell).DataSource = null;
                GC.Collect();
                (DataGridView1.Rows[i].Cells[CONTENT_INDEX] as DataGridViewComboBoxCell).DataSource = AppData.typeDictionary[Records[i].Type];
                (DataGridView1.Rows[i].Cells[CONTENT_INDEX] as DataGridViewComboBoxCell).Value = Records[i].Content;

            }

            // 插入Image col = 8, 9 並且載入發票縮圖
            DataGridView1.Columns.Insert(IMAGE1_COL, new DataGridViewImageColumn { HeaderText = "發票1" });
            DataGridView1.Columns.Insert(IMAGE2_COL, new DataGridViewImageColumn { HeaderText = "發票2" });
            DataGridView1.Columns["Image1"].Visible = false;
            DataGridView1.Columns["Image2"].Visible = false;

            for (int i = 0; i < DataGridView1.RowCount; i++)  // 載入發票縮圖
            {
                DataGridView1.Rows[i].Cells[IMAGE1_COL].Value = imageService.GetThumbnail(i, 1);
                DataGridView1.Rows[i].Cells[IMAGE2_COL].Value = imageService.GetThumbnail(i, 2);
            }

            // 插入edit col = 10
            DataGridView1.Columns.Insert(EDIT_BTN_COL, new DataGridViewImageColumn
            {
                HeaderText = "編輯",
                Image = Image.FromFile($"{ConfigurationManager.AppSettings["serverDir"]}\\Images\\edit.png"),
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });


            // 插入delete col = 11
            DataGridView1.Columns.Insert(DELETE_BTN_COL, new DataGridViewImageColumn
            {
                HeaderText = "刪除",
                Image = Image.FromFile($"{ConfigurationManager.AppSettings["serverDir"]}\\Images\\trash.png"),
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });
        }
    }
}
