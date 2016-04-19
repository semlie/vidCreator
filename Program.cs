using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;

namespace testImageCreateor
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ImageCreatorService();
            var textDir = @"I:\data\videoCraetor\data\text\";
            var imageDir = @"I:\data\videoCraetor\data\images\";
            var musicDir = @"I:\data\videoCraetor\data\music\";

            var engine = new ImageCreatorEngine(imageDir,musicDir,textDir);
            engine.init();
            var imagePath = @"I:\data\videoCraetor\data\images\pink-1328819_1920.jpg";
            var c =File.GetAttributes(imagePath);

           var image = Image.FromFile(imagePath);
            var b = a.MeasureTextPoint("אבי ילד טוב", image);

            var newImage = a.AddTextOnImage("אבי ילד טוב", (Bitmap)image, b);
            newImage.Save("newFile.jpg");
            Console.WriteLine("end");

            //String drawString = "Sample Text";

            //// Create font and brush.
            //Font drawFont = new Font("Arial", 16);
            //SolidBrush drawBrush = new SolidBrush(Color.Black);

            //// Create point for upper-left corner of drawing.
            //PointF drawPoint = new PointF(150.0F, 150.0F);

            //// Draw string to screen.
            //e.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);

    //            CreateImage();
            //var a = (Bitmap)Image.FromFile("picture.bmp");
            //var img = RotateImage(a, 15f);
            //img.Save("picture1.bmp");
            //var txt = "בוקר טוב בוקר טובבוקר טוב בוקר  טוב בוקר  טוב בוקר  טוב   טוב בוקר טוב בוקר טוב";
            //var img2 = DrawText(txt, new Font("Arial", 30), Color.Black, Color.AntiqueWhite);
            //img2.Save("picture2.jpg");
        }
        private static Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width+20, (int)textSize.Height+20);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }
        public static Bitmap RotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 1);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0,0));
            }
            return returnBitmap;
        }

        private static void CreateImage()
        {
            string firstText = "שלום עולם";
            string secondText = "World";

            PointF firstLocation = new PointF(10f, 10f);
            PointF secondLocation = new PointF(10f, 50f);

            string imageFilePath = @"picture.bmp";
            //Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file
            var bitmap = new Bitmap((int)300, (int)300);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Arial", 30))
                {
                    graphics.DrawString(firstText, arialFont, Brushes.Blue, new Point(bitmap.Width/2,bitmap.Height/2));
                    graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
                }
            }

            bitmap.Save(imageFilePath);//save the image file
        }
    }
}
