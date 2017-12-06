using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CVProject
{
    class ImageProcessor
    {
        [DllImport("CVProject.Core.dll", EntryPoint = "modifyImg", CallingConvention = CallingConvention.Cdecl)]
        private extern static void modifyImg(byte[] img, int width, int height);

        public static void DrawLine(WriteableBitmap Image, Point a, Point b)
        {
            byte[] array = Helper.BitmapSourceToByteArray(Image);
            modifyImg(array, Image.PixelWidth, Image.PixelHeight);
            Image.WritePixels(new Int32Rect(0, 0, Image.PixelWidth, Image.PixelHeight), array, Image.PixelWidth * ((Image.Format.BitsPerPixel + 7) / 8), 0);
        }
    }
}
