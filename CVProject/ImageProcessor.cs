﻿ using System;
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
        [DllImport("CVProject.Core.dll", EntryPoint = "binarizeImg", CallingConvention = CallingConvention.Cdecl)]
        public extern static void binarizeImg(IntPtr img, int width, int height, bool RInOut, byte RLow, byte RHigh, bool GInOut, byte GLow, byte GHigh, bool BInOut, byte BLow, byte BHigh);

        [DllImport("CVProject.Core.dll", EntryPoint = "binarizeImgOtsu", CallingConvention = CallingConvention.Cdecl)]
        public extern static void binarizeImg(IntPtr img, int width, int height);

        [DllImport("CVProject.Core.dll", EntryPoint = "toGrayScale", CallingConvention = CallingConvention.Cdecl)]
        public extern static void toGrayScale(IntPtr img, int width, int height, byte grayMode);

        [DllImport("CVProject.Core.dll", EntryPoint = "smooth", CallingConvention = CallingConvention.Cdecl)]
        public extern static void smooth(IntPtr img, int width, int height, double[] kernel, int size);

        [DllImport("CVProject.Core.dll", EntryPoint = "smoothMedian", CallingConvention = CallingConvention.Cdecl)]
        public extern static void smooth(IntPtr img, int width, int height, int size);

        [DllImport("CVProject.Core.dll", EntryPoint = "resize", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr resize(IntPtr img, int width, int height, int nwidth, int nheight, byte mode);

        [DllImport("CVProject.Core.dll", EntryPoint = "rotate", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr rotate(IntPtr img, int width, int height, double degree, byte mode);

        [DllImport("CVProject.Core.dll", EntryPoint = "colorAdjust", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr colorAdjust(IntPtr img, int width, int height, double hdelta, double sfix, double lfix);

        [DllImport("CVProject.Core.dll", EntryPoint = "sobel", CallingConvention = CallingConvention.Cdecl)]
        public extern static void sobel(IntPtr img, int width, int height, int size);

        [DllImport("CVProject.Core.dll", EntryPoint = "laplacian", CallingConvention = CallingConvention.Cdecl)]
        public extern static void laplacian(IntPtr img, int width, int height, int mode);

        [DllImport("CVProject.Core.dll", EntryPoint = "canny", CallingConvention = CallingConvention.Cdecl)]
        public extern static void canny(IntPtr img, int width, int height, int size, int l, int r);

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

        public static void Paste(WriteableBitmap dest, BitmapSource src, System.Windows.Point Offset)
        {
            //dest.WritePixels(new Int32Rect(Math.Max(-Offset.X, 0), Math.Max(-Offset.Y, 0), src.PixelWidth - )
            var tsrc = new WriteableBitmap(src);
            int srcX = (int)Math.Max(-Offset.X, 0), srcY = (int)Math.Max(-Offset.Y, 0);
            int srcWidth = src.PixelWidth - (int)Math.Max(-Offset.X, 0);
            int srcHeight = src.PixelHeight - (int)Math.Max(-Offset.Y, 0);
            srcWidth = (int)Math.Min(srcWidth, dest.PixelWidth - Math.Max(Offset.X, 0));
            srcHeight = (int)Math.Min(srcHeight, dest.PixelHeight - Math.Max(Offset.Y, 0));
            dest.WritePixels(new Int32Rect(srcX, srcY, srcWidth, srcHeight), 
                tsrc.BackBuffer, src.PixelHeight * src.PixelWidth * 4, src.PixelWidth * 4, 
                (int)Math.Max(Offset.X, 0), (int)Math.Max(Offset.Y, 0));
        }

    }
}
