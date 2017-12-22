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

        public static void DrawLine(WriteableBitmap Image, System.Windows.Point a, System.Windows.Point b, Color c, int thickness, Model.DrawMode drawMode)
        {
            Mat m = new Mat(Image.PixelHeight, Image.PixelWidth, MatType.CV_8UC4, Image.BackBuffer);
            Cv2.Line(m, new OpenCvSharp.Point(a.X, a.Y), new OpenCvSharp.Point(b.X, b.Y), new Scalar(c.B, c.G, c.R, c.A), thickness, (LineTypes)(1<<(int)(drawMode + 2)));
        }

        public static void DrawRect(WriteableBitmap Image, System.Windows.Point a, System.Windows.Point b, Color c, int thickness, Model.DrawMode drawMode)
        {
            Mat m = new Mat(Image.PixelHeight, Image.PixelWidth, MatType.CV_8UC4, Image.BackBuffer);
            Cv2.Rectangle(m, new OpenCvSharp.Point(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y)), new OpenCvSharp.Point(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y)), new Scalar(c.B, c.G, c.R, c.A), thickness, (LineTypes)(1 << (int)(drawMode + 2)));
        }

        public static void DrawEllipse(WriteableBitmap Image, System.Windows.Point a, System.Windows.Point b, Color c, int thickness, Model.DrawMode drawMode)
        {
            Mat m = new Mat(Image.PixelHeight, Image.PixelWidth, MatType.CV_8UC4, Image.BackBuffer);
            Cv2.Ellipse(m, new RotatedRect(new Point2f((float)(a.X + b.X) / 2, (float)(a.Y + b.Y) / 2), new Size2f(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y)), 0), new Scalar(c.B, c.G, c.R, c.A), thickness, (LineTypes)(1 << (int)(drawMode + 2)));
        }

        public static void DrawCircle(WriteableBitmap Image, System.Windows.Point a, System.Windows.Point b, Color c, int thickness, Model.DrawMode drawMode)
        {
            Mat m = new Mat(Image.PixelHeight, Image.PixelWidth, MatType.CV_8UC4, Image.BackBuffer);
            Cv2.Circle(m, new OpenCvSharp.Point((a.X + b.X) / 2, (a.Y + b.Y) / 2), (int)Math.Min(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y)) / 2, new Scalar(c.B, c.G, c.R, c.A), thickness, (LineTypes)(1 << (int)(drawMode + 2)));
        }

    }
}
