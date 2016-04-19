using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testImageCreateor
{
    public class ImageCreatorModel
    {
        public string VideoText { get; set; }
        public string VideoImage { get; set; }
        public string VideoBackgroundMusic { get; set; }
        public string ImageDirPath { get; set; }
        public SolidBrush FontColor { get; set; }
        public Font FontSize { get; set; }

        public int Videolangth { get; set; }
    }
}
