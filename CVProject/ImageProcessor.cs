using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenCvSharp;

namespace CVProject
{
    class ImageProcessor
    {
        //[DllImport("CVProject.Core.dll", EntryPoint = "modifyImg", CallingConvention = CallingConvention.Cdecl)]
       // private extern static void modifyImg(byte[] img, int width, int height);

        public static void Init()
        {            
            
        }

        private static Mat ByteArray2Mat(byte[] bytearray, int width, int height)
        {
            GCHandle hObject = GCHandle.Alloc(bytearray, GCHandleType.Pinned);
            IntPtr arrayPtr = hObject.AddrOfPinnedObject();
            Mat m = new Mat(height, width, MatType.CV_8UC4, arrayPtr);
            hObject.Free();
            return m;
        }

        public static void DrawLine(WriteableBitmap Image, System.Windows.Point a, System.Windows.Point b, Color c)
        {
            byte[] array = Helper.BitmapSourceToByteArray(Image);
            Mat m = ByteArray2Mat(array, Image.PixelWidth, Image.PixelHeight);
            Cv2.Line(m, new OpenCvSharp.Point(a.X, a.Y), new OpenCvSharp.Point(b.X, b.Y), new Scalar(c.B, c.G, c.R, c.A), 1, LineTypes.AntiAlias);
            Image.WritePixels(new Int32Rect(0, 0, Image.PixelWidth, Image.PixelHeight), array, Image.PixelWidth * ((Image.Format.BitsPerPixel + 7) / 8), 0);
        }
    }
}
