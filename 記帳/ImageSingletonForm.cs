using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 記帳
{
    internal class ImageSingletonForm
    {
        private static ImageForm imageForm;
        
        protected ImageSingletonForm() { }

        public static ImageForm GetImageForm()
        {
            if (imageForm == null)
            {
                imageForm = new ImageForm();
            }

            return imageForm;
        }
    }
}
