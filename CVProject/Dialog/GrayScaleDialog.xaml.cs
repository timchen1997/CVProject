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
    /// GrayScaleDialog.xaml 的交互逻辑
    /// </summary>
    public partial class GrayScaleDialog : Window
    {
        private enum GrayMode { Auto = 0, Red = 1, Green = 2, Blue = 3}
        private MainWindow father;

        public GrayScaleDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
            radiobtnAuto.IsChecked = true;
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
        }

        private void refreshImage()
        {
            if (father == null) return;
            var t = father.curEnv.imgFile.Recover();
            if (radiobtnAuto.IsChecked == true)
                ImageProcessor.toGrayScale(t.BackBuffer, t.PixelWidth, t.PixelHeight, (byte)GrayMode.Auto);
            else if (radiobtnR.IsChecked == true)
                ImageProcessor.toGrayScale(t.BackBuffer, t.PixelWidth, t.PixelHeight, (byte)GrayMode.Red);
            else if (radiobtnG.IsChecked == true)
                ImageProcessor.toGrayScale(t.BackBuffer, t.PixelWidth, t.PixelHeight, (byte)GrayMode.Green);
            else if (radiobtnB.IsChecked == true)
                ImageProcessor.toGrayScale(t.BackBuffer, t.PixelWidth, t.PixelHeight, (byte)GrayMode.Blue);
            father.curEnv.imgFile.Commit();
            father.curEnv.refresh();
        }
    }
}
