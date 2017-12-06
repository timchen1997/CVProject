using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using CVProject.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;

namespace CVProject
{
    class Helper
    {
        public static Color Int2Color(int c)
        {
            var r = Color.FromArgb((byte)(c >> 24), (byte)(c >> 16 & 0xff), (byte)(c >> 8 & 0xff), (byte)(c & 0xff));
            return r;
        }

        public static double getSystemDpiX()
        {
            return 96;
        }

        public static double getSystemDpiY()
        {
            return 96;
        }

        public static void Rgb2Hsl(Color c, out double H, out double S, out double L)
        {
            byte max = Math.Max(c.R, Math.Max(c.G, c.B));
            byte min = Math.Min(c.R, Math.Min(c.G, c.B));
            if (max == min)
                H = 0;
            else if (max == c.R && c.G >= c.B)
                H = 60 * (c.G - c.B) / (double)(max - min);
            else if (max == c.R && c.G < c.B)
                H = 60 * (c.G - c.B) / (double)(max - min) + 360;
            else if (max == c.G)
                H = 60 * (c.B - c.R) / (double)(max - min) + 120;
            else
                H = 60 * (c.R - c.G) / (double)(max - min) + 240;
            L = (max + min) / 2 / 255.0 * 100;
            if (L == 0 || max == min)
                S = 0;
            else if (L <= 50)
                S = (max - min) / (double)(max + min) * 100;
            else
                S = (max - min) / (double)(510 - max - min) * 100;
        }

        public static T DeepClone<T>(T a)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static byte[] BitmapSourceToByteArray(BitmapSource bmp)
        {
            byte[] bytearray = new byte[bmp.PixelHeight * bmp.PixelWidth * ((bmp.Format.BitsPerPixel + 7) / 8)];
            bmp.CopyPixels(bytearray, bmp.PixelWidth * ((bmp.Format.BitsPerPixel + 7) / 8), 0);
            return bytearray;
        }

        public static IntPtr getIntPtr(byte[] array)
        {
            GCHandle hObject = GCHandle.Alloc(array, GCHandleType.Pinned);
            return hObject.AddrOfPinnedObject();
        }

    }
}
