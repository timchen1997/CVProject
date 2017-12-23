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
    /// SmoothingDialog.xaml 的交互逻辑
    /// </summary>
    public partial class SmoothingDialog : Window
    {
        private MainWindow father;
        private Xceed.Wpf.Toolkit.DecimalUpDown[,] kernel = new Xceed.Wpf.Toolkit.DecimalUpDown[7, 7];
        private int size
        {
            get
            {
                return cboxSize.SelectedIndex * 2 + 3;
            }
        }

        public SmoothingDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                {
                    var t = kernel[i, j] = new Xceed.Wpf.Toolkit.DecimalUpDown();
                    kernelGrid.Children.Add(t);
                    Grid.SetRow(t, i);
                    Grid.SetColumn(t, j);
                    t.VerticalAlignment = VerticalAlignment.Center;
                    t.HorizontalAlignment = HorizontalAlignment.Center;
                }
            refreshKernel();
        }

        private void refreshKernel()
        {
            if (kernel[0, 0] == null) return;
            disableAll();
            setKernelValue();
            if (cboxMode.SelectedIndex == 3)
                enable(size);
        }

        private void setKernelValue()
        {
            switch (cboxMode.SelectedIndex)
            {
                case 0:
                    for (int i = (7 - size) / 2; i < 7 - (7 - size) / 2; i++)
                        for (int j = (7 - size) / 2; j < 7 - (7 - size) / 2; j++)
                            kernel[i, j].Value = Convert.ToDecimal((double)1 / size / size);
                    break;
                case 1:
                    for (int i = (7 - size) / 2; i < 7 - (7 - size) / 2; i++)
                        for (int j = (7 - size) / 2; j < 7 - (7 - size) / 2; j++)
                            kernel[i, j].Value = 0;
                    break;
                case 2:
                    double sum = 0, sigma = 1;
                    int center = size / 2;
                    for (int i = 0; i < size; i++)
                    {
                        double x2 = Math.Pow(i - center, 2);
                        for (int j = 0; j < size; j++)
                        {
                            double y2 = Math.Pow(j - center, 2);
                            double g = Math.Exp(-(x2 + y2) / (2 * sigma * sigma));
                            g /= 2 * Math.PI * sigma;
                            sum += g;
                            kernel[i + (7 - size) / 2, j + (7 - size) / 2].Value = Convert.ToDecimal(g);
                        }
                    }
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            kernel[i + (7 - size) / 2, j + (7 - size) / 2].Value = Convert.ToDecimal((double)kernel[i + (7 - size) / 2, j + (7 - size) / 2].Value.Value / sum);
                        }
                    }
                    break;
            }
        }

        private void disableAll()
        {
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                {
                    kernel[i, j].IsEnabled = false;
                    kernel[i, j].Value = null;
                }
        }

        private void enable(int size)
        {
            for (int i = (7 - size) / 2; i < 7 - (7 - size) / 2; i++)
                for (int j = (7 - size) / 2; j < 7 - (7 - size) / 2; j++)
                    kernel[i, j].IsEnabled = true;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            father.curEnv.Advance("Smooth");
            var t = father.curEnv.imgFile.curImage as WriteableBitmap;
            if (cboxMode.SelectedIndex != 1)
            {
                double[] kernelArray = new double[size * size];
                for (int i = (7 - size) / 2; i < 7 - (7 - size) / 2; i++)
                    for (int j = (7 - size) / 2; j < 7 - (7 - size) / 2; j++)
                        kernelArray[(i - (7 - size) / 2) * size + (j - (7 - size) / 2)] = (double)kernel[i, j].Value.Value;
                ImageProcessor.smooth(t.BackBuffer, t.PixelWidth, t.PixelHeight, kernelArray, size);
            }
            else
                ImageProcessor.smooth(t.BackBuffer, t.PixelWidth, t.PixelHeight, size);
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshKernel();
        }
    }
}
