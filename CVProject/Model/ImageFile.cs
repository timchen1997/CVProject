using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CVProject.Model
{
    public class ImageHistory
    {
        public WriteableBitmap img { set; get; }
        public string description { set; get; }

        public ImageHistory(WriteableBitmap img, string description)
        {
            this.img = img;
            this.description = description;
        }
    }


    public class ImageFile
    {
        private enum ImageFormat { Bmp, Jpg, Png};

        public ObservableCollection<ImageHistory> ImageList { set; get; }
        public string FullPath { set; get; }
        public string FileName { set; get; }
        private ImageFormat Format { set; get; }
        private WriteableBitmap store { set; get; }
        public int curStateNo { set; get; }
        public BitmapSource curImage
        {
            get
            {
                return ImageList[curStateNo].img;
            }
        }
        public ImageSource prevImage
        {
            get
            {
                return ImageList[curStateNo - 1].img;
            }
        }

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
            ImageList = new ObservableCollection<ImageHistory>();
            var Img = BitmapFrame.Create(uri);
            var WBitmap = new WriteableBitmap(Img);
            ImageList.Add(new ImageHistory(WBitmap, "Open File"));
            curStateNo = 0;
        }

        public ImageFile(int width, int height, int dpi)
        {
            FileName = "Untitled";
            ImageList = new ObservableCollection<ImageHistory>();
            uint[] buffer = new uint[width * height];
            for (uint i = 0; i < width * height; i++)
                buffer[i] = 0xffffffff;
            var WBitmap = new WriteableBitmap(width, height, dpi, dpi, PixelFormats.Bgr32, null);
            WBitmap.WritePixels(new Int32Rect(0, 0, width, height), buffer, width * 4, 0);
            ImageList.Add(new ImageHistory(WBitmap, "New File"));
            curStateNo = 0;
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
            if (FullPath == null) SaveAs();
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
            encoder.Frames.Add(BitmapFrame.Create(curImage));
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

        public void Undo()
        {
            if (curStateNo == 0) return;
            curStateNo--;
        }

        public void Redo()
        {
            if (curStateNo == ImageList.Count - 1) return;
            curStateNo++;
        }

        public void ChangeState(int stateNo)
        {
            if (stateNo == -1) return;
            curStateNo = stateNo;
        }

        public void Advance(string description)
        {
            var newBitmap = (curImage as WriteableBitmap).Clone();
            Advance(description, newBitmap);
        }

        public void Advance(string description, WriteableBitmap newBitmap)
        {
            var ih = new ImageHistory(newBitmap, description);
            curStateNo++;
            if (curStateNo == ImageList.Count)
                ImageList.Add(ih);
            else
            {
                ImageList[curStateNo] = ih;
                for (int i = ImageList.Count - 1; i > curStateNo; i--)
                    ImageList.RemoveAt(i);
            }
        }

        public WriteableBitmap Recover()
        {
            store = (prevImage as WriteableBitmap).Clone();
            return store;
        }

        public void Commit()
        {
            ImageList[curStateNo].img = store;
        }

        public void Refresh()
        {
            (curImage as WriteableBitmap).Lock();
            (curImage as WriteableBitmap).AddDirtyRect(new Int32Rect(0, 0, curImage.PixelWidth, curImage.PixelHeight));
            (curImage as WriteableBitmap).Unlock();
        }

        public BitmapSource Part(Point a, Point b)
        {
            int x1 = (int) Math.Min(a.X, b.X),
                x2 = (int) Math.Max(a.X, b.X),
                y1 = (int) Math.Min(a.Y, b.Y),
                y2 = (int) Math.Max(a.Y, b.Y);
            byte[] buffer = new byte[(x2 - x1) * (y2 - y1) * curImage.Format.BitsPerPixel];
            curImage.CopyPixels(new Int32Rect(x1, y1, x2 - x1, y2 - y1), buffer, (x2 - x1) * curImage.Format.BitsPerPixel, 0);
            var r = BitmapSource.Create(x2 - x1, y2 - y1, curImage.DpiX, curImage.DpiY, curImage.Format, curImage.Palette, buffer, (x2 - x1) * curImage.Format.BitsPerPixel);
            return r;
        }
    }
}
