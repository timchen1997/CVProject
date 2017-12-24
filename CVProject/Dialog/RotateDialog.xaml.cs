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
    /// RotateDialog.xaml 的交互逻辑
    /// </summary>
    public partial class RotateDialog : Window
    {
        private MainWindow father;
        public RotateDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            var t = father.curEnv.imgFile.curImage as WriteableBitmap;
            double deg = (double)degree.Value.Value / 180 * Math.PI;
            IntPtr newBuffer = ImageProcessor.rotate(t.BackBuffer, t.PixelWidth, t.PixelHeight, deg, (byte)cboxMode.SelectedIndex);
            int nwidth = (int)Math.Ceiling(Math.Abs(t.PixelWidth * Math.Cos(deg)) + Math.Abs(t.PixelHeight * Math.Sin(deg)));
            int nheight = (int)Math.Ceiling(Math.Abs(t.PixelHeight * Math.Cos(deg)) + Math.Abs(t.PixelWidth * Math.Sin(deg)));
            var newImg = new WriteableBitmap(nwidth, nheight, t.DpiX, t.DpiY, t.Format, t.Palette);
            newImg.WritePixels(new Int32Rect(0, 0, nwidth, nheight), newBuffer, nwidth * nheight * 4, nwidth * 4);
            father.curEnv.Advance("Rotate", newImg);
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
