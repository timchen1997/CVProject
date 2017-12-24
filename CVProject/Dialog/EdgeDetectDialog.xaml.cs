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
    /// EdgeDetectDialog.xaml 的交互逻辑
    /// </summary>
    public partial class EdgeDetectDialog : Window
    {
        private MainWindow father;
        public EdgeDetectDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
            rbtnSobel.IsChecked = true;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            father.curEnv.Advance("Edge Detect");
            var t = father.curEnv.imgFile.curImage as WriteableBitmap;
            if (rbtnSobel.IsChecked == true)
                ImageProcessor.sobel(t.BackBuffer, t.PixelWidth, t.PixelHeight, 3);
            else if (rbtnLaplacian.IsChecked == true)
                ImageProcessor.laplacian(t.BackBuffer, t.PixelWidth, t.PixelHeight, cboxMode.SelectedIndex);
            else
                ImageProcessor.canny(t.BackBuffer, t.PixelWidth, t.PixelHeight, cboxKSize.SelectedIndex * 2 + 3, (int)l.Value.Value, (int)r.Value.Value);
            father.curEnv.refresh();
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            gboxSobel.IsEnabled = false;
            gboxLaplacian.IsEnabled = false;
            gboxCanny.IsEnabled = false;
            if (rbtnSobel.IsChecked == true)
                gboxSobel.IsEnabled = true;
            else if (rbtnLaplacian.IsChecked == true)
                gboxLaplacian.IsEnabled = true;
            else
                gboxCanny.IsEnabled = true;
        }
    }
}
