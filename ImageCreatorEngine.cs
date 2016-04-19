using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testImageCreateor
{
    public class ImageCreatorEngine
    {
        public ImageCreatorModel VideoModel = new ImageCreatorModel();
        private ImageCreatorService ImageService = new ImageCreatorService();
        private string ImagePath;
        private string MusicPath;
        private string TextPath;
        public ImageCreatorEngine(string imagePath, string musicPath, string textPath)
        {
            ImagePath = imagePath;
            MusicPath = musicPath;
            TextPath = textPath;

        }
        public void init()
        {
            VideoModel.VideoText = GetVideoText(GetTextFile());
            VideoModel.VideoImage = GetVideoImage();
            VideoModel.VideoBackgroundMusic = GetBackroundMusic();
        }

        private string[] getFilesInDir(string path)
        {
            string[] filePaths = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
            return filePaths;
        }

        public string GetVideoImage()
        {
            var files = getFilesInDir(ImagePath);
            return files[new Random().Next(0, files.Length)];
        }



        private string GetTextFile()
        {

            var files = getFilesInDir(TextPath);
            return files[new Random().Next(0, files.Length)];
        }

        private string GetVideoText(string file)
        {
            return System.IO.File.ReadAllText(file);
        }

        private string GetBackroundMusic()
        {
            var files = getFilesInDir(MusicPath);
            return files[new Random().Next(0, files.Length)];
        }
    }
}
