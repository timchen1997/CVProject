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

        [DllImport("CVProject.Core.dll", EntryPoint = "ArithmeticOper", CallingConvention = CallingConvention.Cdecl)]
        public extern static void ArithmeticOper(IntPtr imgA, int widthA, int heightA, IntPtr imgB, int widthB, int heightB, double ratioA, double ratioB, int oper);

        [DllImport("CVProject.Core.dll", EntryPoint = "contrastLinear", CallingConvention = CallingConvention.Cdecl)]
        public extern static void contrastLinear(IntPtr img, int width, int height, byte x1, byte x2, byte y1, byte y2);

        [DllImport("CVProject.Core.dll", EntryPoint = "contrastLog", CallingConvention = CallingConvention.Cdecl)]
        public extern static void contrastLog(IntPtr img, int width, int height, double c);

        [DllImport("CVProject.Core.dll", EntryPoint = "contrastExp", CallingConvention = CallingConvention.Cdecl)]
        public extern static void contrastExp(IntPtr img, int width, int height, double c);

        [DllImport("CVProject.Core.dll", EntryPoint = "erode", CallingConvention = CallingConvention.Cdecl)]
        public extern static void erode(IntPtr img, int width, int height, byte[] kernel);

        [DllImport("CVProject.Core.dll", EntryPoint = "dilate", CallingConvention = CallingConvention.Cdecl)]
        public extern static void dilate(IntPtr img, int width, int height, byte[] kernel);

        [DllImport("CVProject.Core.dll", EntryPoint = "open", CallingConvention = CallingConvention.Cdecl)]
        public extern static void open(IntPtr img, int width, int height, byte[] kernel);

        [DllImport("CVProject.Core.dll", EntryPoint = "close", CallingConvention = CallingConvention.Cdecl)]
        public extern static void close(IntPtr img, int width, int height, byte[] kernel);

        [DllImport("CVProject.Core.dll", EntryPoint = "skeleton", CallingConvention = CallingConvention.Cdecl)]
        public extern static void skeleton(IntPtr img, int width, int height, byte[] kernel);

        [DllImport("CVProject.Core.dll", EntryPoint = "skeletonRebuild", CallingConvention = CallingConvention.Cdecl)]
        public extern static void skeletonRebuild(IntPtr img, int width, int height, byte[] kernel);

        [DllImport("CVProject.Core.dll", EntryPoint = "morphologicalReconstruct", CallingConvention = CallingConvention.Cdecl)]
        public extern static void morphologicalReconstruct(IntPtr a, IntPtr b, int width, int height, byte[] kernel);

        [DllImport("CVProject.Core.dll", EntryPoint = "thin", CallingConvention = CallingConvention.Cdecl)]
        public extern static void thin(IntPtr img, int width, int height, byte[] kernel);

        [DllImport("CVProject.Core.dll", EntryPoint = "thick", CallingConvention = CallingConvention.Cdecl)]
        public extern static void thick(IntPtr img, int width, int height, byte[] kernel);

        [DllImport("CVProject.Core.dll", EntryPoint = "distanceTrans", CallingConvention = CallingConvention.Cdecl)]
        public extern static void distanceTrans(IntPtr img, int width, int height);

        [DllImport("CVProject.Core.dll", EntryPoint = "watershed", CallingConvention = CallingConvention.Cdecl)]
        public extern static void watershed(IntPtr img, int width, int height);

        [DllImport("CVProject.Core.dll", EntryPoint = "houghLine", CallingConvention = CallingConvention.Cdecl)]
        private extern static int __houghLine(IntPtr img, int width, int height, int threshold, int[] lineList);

        [DllImport("CVProject.Core.dll", EntryPoint = "houghCircle", CallingConvention = CallingConvention.Cdecl)]
        private extern static int __houghCircle(IntPtr img, int width, int height, int threshold, int rmin, int rmax, int[] circleList);

        public static void houghLine(WriteableBitmap Image, int threshold)
        {
            int[] lineList = new int[Image.PixelHeight * Image.PixelHeight];
            int lineNum = __houghLine(Image.BackBuffer, Image.PixelWidth, Image.PixelHeight, threshold, lineList);
            for (int i = 0; i < lineNum; i++)
            {
                int r = lineList[2 * i], theta = lineList[2 * i + 1];
                var pa = new System.Windows.Point(0, r / Math.Cos(theta / 180.0 * Math.PI));
                var pb = new System.Windows.Point(Image.PixelWidth, r / Math.Cos(theta / 180.0 * Math.PI) - Image.PixelWidth * Math.Tan(theta / 180.0 * Math.PI));
                DrawLine(Image, pa, pb, Color.FromArgb(255, 255, 0, 0), 1, Model.DrawMode.Link4);
            }
        }

        public static void houghCircle(WriteableBitmap Image, int threhold, int rmin, int rmax)
        {
            int[] circleList = new int[Image.PixelHeight * Image.PixelHeight];
            int lineNum = __houghCircle(Image.BackBuffer, Image.PixelWidth, Image.PixelHeight, threhold, rmin, rmax, circleList);
            for (int i = 0; i < lineNum; i++)
            {
                int b = circleList[3 * i], a = circleList[3 * i + 1], r = circleList[3 * i + 2];
                var pa = new System.Windows.Point(a - r, b - r);
                var pb = new System.Windows.Point(a + r, b + r);
                DrawCircle(Image, pa, pb, Color.FromArgb(255, 255, 0, 0), 1, Model.DrawMode.Link4);
            }
        }

        [DllImport("CVProject.Core.dll", EntryPoint = "histogramBalance", CallingConvention = CallingConvention.Cdecl)]
        public extern static void histogramBalance(IntPtr img, int width, int height);

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
