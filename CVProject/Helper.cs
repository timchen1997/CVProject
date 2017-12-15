using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
    }
}
