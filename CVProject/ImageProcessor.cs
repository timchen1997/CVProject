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

        public static void DrawLine(WriteableBitmap Image, System.Windows.Point a, System.Windows.Point b, Color c)
        {
            Mat m = new Mat(Image.PixelHeight, Image.PixelWidth, MatType.CV_8UC4, Image.BackBuffer);
            Cv2.Line(m, new OpenCvSharp.Point(a.X, a.Y), new OpenCvSharp.Point(b.X, b.Y), new Scalar(c.B, c.G, c.R, c.A), 1, LineTypes.AntiAlias);
        }
    }
}
