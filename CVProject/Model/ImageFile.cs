﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CVProject.Model
{
    class ImageHistory
    {
        public WriteableBitmap img { set; get; }
        public string description { set; get; }

        public ImageHistory(WriteableBitmap img, string description)
        {
            this.img = img;
            this.description = description;
        }
    }


    class ImageFile
    {
        private enum ImageFormat { Bmp, Jpg, Png};

        public ObservableCollection<ImageHistory> ImageList { set; get; }
        public string FullPath { set; get; }
        public string FileName { set; get; }
        private ImageFormat Format { set; get; }
        public int curStateNo { set; get; }
        public ImageSource curImage
        {
            get
            {
                return ImageList[curStateNo].img;
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

        public WriteableBitmap getCurImg()
        {
            return ImageList[curStateNo].img;
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
            curStateNo = stateNo;
        }

        public void Advance(string description)
        {
            var newBitmap = Helper.DuplicateWritableBitmap(getCurImg());
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
    }
}
