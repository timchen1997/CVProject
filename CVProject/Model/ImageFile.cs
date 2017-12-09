using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CVProject.Model
{

    class ImageFile
    {
        private enum ImageFormat { Bmp, Jpg, Png};

        private List<WriteableBitmap> ImageList { set; get; }
        public string FullPath { set; get; }
        public string FileName { set; get; }
        private ImageFormat Format { set; get; }
        private int curStateNo { set; get; }

        private ImageFormat DetectFormat(string name)
        {
            switch (name.Split('.').Last().ToLower())
            {
                case "bmp":
                    return ImageFormat.Bmp;
                case "jpg": case "jpeg":
                    return ImageFormat.Jpg;
                case "png":
                    return ImageFormat.Png;
                default:
                    return ImageFormat.Bmp;
            }
        }

        public ImageFile(Uri uri)
        {
            FullPath = uri.LocalPath;
            FileName = FullPath.Split('\\').Last();
            Format = DetectFormat(FileName);
            ImageList = new List<WriteableBitmap>();
            var Img = BitmapFrame.Create(uri);
            var WBitmap = new WriteableBitmap(Img);
            ImageList.Add(WBitmap);
            curStateNo = 0;
        }

        public WriteableBitmap getCurImg()
        {
            return ImageList[curStateNo];
        }

        public static ImageFile Open()
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "All Support Format|*.bmp;*.jpg;*.jpeg;*.png|Bitmap File|*.bmp|JPEG File|*.jpg;*.jpeg|PNG File|*.png";
            if (dialog.ShowDialog() == true)
            {
                var imgFile = new ImageFile(new Uri(dialog.FileName));
                return imgFile;
            }
            return null;
        }

        public void Save()
        {
            BitmapEncoder encoder;
            switch (Format)
            {
                case ImageFormat.Bmp:
                    encoder = new BmpBitmapEncoder();
                    break;
                case ImageFormat.Jpg:
                    encoder = new JpegBitmapEncoder();
                    (encoder as JpegBitmapEncoder).QualityLevel = (new Dialog.JpegSaveDialog()).Quality;
                    break;
                case ImageFormat.Png:
                    encoder = new PngBitmapEncoder();
                    break;
                default:
                    encoder = new BmpBitmapEncoder();
                    break;
            }
            encoder.Frames.Add(BitmapFrame.Create(getCurImg()));
            using (var fileStream = new System.IO.FileStream(FullPath, System.IO.FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }

        public void SaveAs()
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "Bitmap File|*.bmp|JPEG File|*.jpg;*.jpeg|PNG File|*.png";
            dialog.AddExtension = true;
            dialog.FileName = FileName.Split('.')[0];
            dialog.DefaultExt = Format.ToString();
            if (dialog.ShowDialog() == true)
            {
                FullPath = dialog.FileName;
                FileName = FullPath.Split('\\').Last();
                Format = DetectFormat(FileName);
                Save();
            }
        }
    }
}
