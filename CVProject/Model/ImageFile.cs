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
        private List<WriteableBitmap> ImageList { set; get; }
        public string FullPath { set; get; }
        public string FileName { set; get; }
        private int curStateNo { set; get; }

        public ImageFile(Uri uri)
        {
            FileName = uri.AbsolutePath;
            FullPath = uri.AbsolutePath;
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
            ;
        }

        public void SaveAs()
        {
            ;
        }
    }
}
