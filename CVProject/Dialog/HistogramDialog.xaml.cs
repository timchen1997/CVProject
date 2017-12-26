using InteractiveDataDisplay.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CVProject.Dialog
{
    /// <summary>
    /// HistogramDialog.xaml 的交互逻辑
    /// </summary>
    public partial class HistogramDialog : Window
    {
        private MainWindow father;
        public HistogramDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
            int[] x = new int[256];
            int[] r = new int[256];
            int[] g = new int[256];
            int[] b = new int[256];

            var t = father.curEnv.imgFile.curImage as WriteableBitmap;

            unsafe
            {
                byte *p = (byte *)t.BackBuffer;
                for (int i = 0; i < t.PixelWidth * t.PixelHeight; i++)
                {
                    b[p[4 * i]]++;
                    g[p[4 * i + 1]]++;
                    r[p[4 * i + 2]]++;
                }
            }

            for (int i = 0; i < x.Length; i++)
                x[i] = i;


            var lgr = new LineGraph();
            lines.Children.Add(lgr);
            lgr.Stroke = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            lgr.StrokeThickness = 2;
            lgr.Plot(x, r.Select(c => c / (double)(t.PixelHeight * t.PixelWidth)));

            var lgg = new LineGraph();
            lines.Children.Add(lgg);
            lgg.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            lgg.StrokeThickness = 2;
            lgg.Plot(x, g.Select(c => c / (double)(t.PixelHeight * t.PixelWidth)));

            var lgb = new LineGraph();
            lines.Children.Add(lgb);
            lgb.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            lgb.StrokeThickness = 2;
            lgb.Plot(x, b.Select(c => c / (double)(t.PixelHeight * t.PixelWidth)));

        }

        
    }
    public class VisibilityToCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Visibility)value) == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
