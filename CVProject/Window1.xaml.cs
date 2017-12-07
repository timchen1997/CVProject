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

namespace CVProject
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Line l = new Line();
            l.StrokeThickness = 1;
            l.Stroke = Brushes.Red;
            l.X1 = 0;
            l.Y1 = 100;
            l.X2 = 0;
            l.Y2 = 100;
            g.Children.Add(l);
        }
    }
}
