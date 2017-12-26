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
    /// ContrastDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ContrastDialog : Window
    {
        private MainWindow father;
        private int[] x = new int[4];
        private int[] y = new int[4];
        private LineGraph lg = new LineGraph();

        public ContrastDialog(MainWindow father)
        {
            InitializeComponent();
            lines.Children.Add(lg);
            lg.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            lg.StrokeThickness = 2;
            x[0] = y[0] = 0;
            x[3] = y[3] = 255;
            this.father = father;
            rbtnLinear.IsChecked = true;
        }

        private void refreshChart()
        {
            if (father == null) return;
            if (x1.Value == null || x2.Value == null || y1.Value == null || y2.Value == null) return;
            x[1] = x1.Value.Value;
            x[2] = x2.Value.Value;
            y[1] = y1.Value.Value;
            y[2] = y2.Value.Value;
            lg.Plot(x, y);
        }

        private void refreshImage()
        {
            if (father == null) return;
            var t = father.curEnv.imgFile.Recover();
            if (rbtnBal.IsChecked == true)
                ImageProcessor.histogramBalance(t.BackBuffer, t.PixelWidth, t.PixelHeight);
            if (rbtnLinear.IsChecked == true)
                ImageProcessor.contrastLinear(t.BackBuffer, t.PixelWidth, t.PixelHeight, (byte)x[1], (byte)x[2], (byte)y[1], (byte)y[2]);
            if (rbtnExp.IsChecked == true)
                ImageProcessor.contrastExp(t.BackBuffer, t.PixelWidth, t.PixelHeight, expV.Value.Value);
            if (rbtnLog.IsChecked == true)
                ImageProcessor.contrastLog(t.BackBuffer, t.PixelWidth, t.PixelHeight, logV.Value.Value);
            father.curEnv.imgFile.Commit();
            father.curEnv.refresh();
            
        }

        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            refreshChart();
            refreshImage();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            refreshImage();
            gboxLinear.IsEnabled = false;
            gboxExp.IsEnabled = false;
            gboxLog.IsEnabled = false;
            if (rbtnLinear.IsChecked == true)
                gboxLinear.IsEnabled = true;
            if (rbtnExp.IsChecked == true)
                gboxExp.IsEnabled = true;
            if (rbtnLog.IsChecked == true)
                gboxLog.IsEnabled = true;
        }
    }
}
