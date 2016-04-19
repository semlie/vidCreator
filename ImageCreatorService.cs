using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testImageCreateor
{
    public class ImageCreatorService
    {
        private ImageCreatorModel m_imageCraetorModel;

        public ImageCreatorService()
        {
            //m_imageCraetorModel = new ImageCreatorModel
            //{
            //    VideoBackgroundMusic = GetRandomBackroundMusic(),
            //    VideoImage = GetRandomBackroundImage(),
            //    VideoText = GetRandomVideoText()
            //};
        }


        public string MeasureVideoTime()
        {
            return default(string);
        }

        public SizeF MeasureTextPoint(string text,Image img)
        {
            Graphics drawing = Graphics.FromImage(img);
            var result = drawing.MeasureString(text, new Font("Arial", 120));
            var size = new SizeF(img.Width, img.Height);
            var sizeResult = new SizeF((size.Width - result.Width) / 2, (size.Height - result.Height) / 2);
            return sizeResult;
        }


        public Bitmap CreateImage()
        {
            return new Bitmap(m_imageCraetorModel.VideoImage);
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(GetBase256Number(), GetBase256Number(), GetBase256Number());
        }

        private int GetBase256Number()
        {
            var randInt = new Random();
            return randInt.Next(50, 256);

        }
        public Bitmap AddTextOnImage(string text,Bitmap image,SizeF position)
        {
            var color = new SolidBrush(GetRandomColor());
            using (Graphics graphics = Graphics.FromImage(image))
            {
                using (Font arialFont = new Font("Arial", 120))
                {
                    graphics.DrawString(text, arialFont, color, new PointF(position.Width, position.Height));
                    graphics.Save();
                }
            }
            return image;

        }

    }
}
