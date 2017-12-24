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
    /// ResizeDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ResizeDialog : Window
    {
        private MainWindow father;
        public ResizeDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
            width.Value = father.curEnv.imgFile.curImage.PixelWidth;
            height.Value = father.curEnv.imgFile.curImage.PixelHeight;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            var t = father.curEnv.imgFile.curImage as WriteableBitmap;
            int nwidth = (int)width.Value.Value, nheight = (int)height.Value.Value;
            IntPtr newBuffer = ImageProcessor.resize(t.BackBuffer, t.PixelWidth, t.PixelHeight, nwidth, nheight, (byte)cboxMode.SelectedIndex);
            var newImg = new WriteableBitmap(nwidth, nheight, t.DpiX, t.DpiY, t.Format, t.Palette);
            newImg.WritePixels(new Int32Rect(0, 0, nwidth, nheight), newBuffer, nwidth * nheight * 4, nwidth * 4);
            father.curEnv.Advance("Resize", newImg);
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
