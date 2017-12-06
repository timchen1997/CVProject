using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenCvSharp;
using OpenTK.Input;

namespace CVProject
{
    class ImageProcessor
    {
        //[DllImport("CVProject.Core.dll", EntryPoint = "modifyImg", CallingConvention = CallingConvention.Cdecl)]
       // private extern static void modifyImg(byte[] img, int width, int height);

        public static void Init()
        {
            
            
        }

        public static void DrawLine(WriteableBitmap Image, System.Windows.Point a, System.Windows.Point b)
        {
            byte[] array = Helper.BitmapSourceToByteArray(Image);
            GCHandle hObject = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr arrayPtr = hObject.AddrOfPinnedObject();
            Mat m = new Mat(Image.PixelHeight, Image.PixelWidth, MatType.CV_8UC4, arrayPtr);
            Mat n = new Mat(@"E:\wallpaper\sss.png");
            Cv2.Line(m, new OpenCvSharp.Point(a.X, a.Y), new OpenCvSharp.Point(b.X, b.Y), new Scalar(0.5, 0.5, 0.5, 0.5), 1, LineTypes.AntiAlias);
            Image.WritePixels(new Int32Rect(0, 0, Image.PixelWidth, Image.PixelHeight), array, Image.PixelWidth * ((Image.Format.BitsPerPixel + 7) / 8), 0);
            hObject.Free();
        }
    }
}
