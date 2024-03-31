using 記帳;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 記帳
{
    internal class ImageService
    {
        private List<RecordModel> records;

        public ImageService(List<RecordModel> records)
        {
            this.records = records;
        }

        public Image GetThumbnail(int rowNum, int imageNum)
        {
            if (imageNum < 0 || imageNum > 3) return null;

            Image image = GetFullImage(rowNum, imageNum);
            Image thumbnail = ResizeImage(image, 50, 50);

            return thumbnail;
        }

        public string GetImagePath(int rowNum, int imageNum)
        {
            if (imageNum < 0 || imageNum > 3) return null;

            string imagePath = (imageNum == 1) ? records[rowNum].Image1 : records[rowNum].Image2;

            if (!string.IsNullOrEmpty(imagePath))
                return imagePath;
            else
                return null;
        }

        public Image GetFullImage(int rowNum, int imageNum)
        {
            if (imageNum < 0 || imageNum > 3) return null;

            string imagePath = (imageNum == 1) ? records[rowNum].Image1 : records[rowNum].Image2;

            if (!string.IsNullOrEmpty(imagePath))
                return Image.FromFile(imagePath);
            else
                return null;
        }

        public Image ResizeImage(Image originalImage, int width, int height)
        {
            if (originalImage == null) return null;

            Bitmap thumbnail = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(thumbnail))
            {
                g.DrawImage(originalImage, 0, 0, width, height);
            }
            return thumbnail;
        }
    }
}
