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
    /// PasteDialog.xaml 的交互逻辑
    /// </summary>
    public partial class PasteDialog : Window
    {
        private MainWindow father;
        private BitmapSource pastedImage;
        public PasteDialog(MainWindow father)
        {
            InitializeComponent();
            pastedImage = Clipboard.GetImage();
            this.father = father;
            OffX.Maximum = father.curEnv.imgFile.curImage.PixelWidth;
            OffY.Maximum = father.curEnv.imgFile.curImage.PixelHeight;
            OffX.Minimum = -pastedImage.PixelWidth;
            OffY.Minimum = -pastedImage.PixelHeight;
            refreshImage();
        }

        private void refreshImage()
        {
            if (father == null) return;
            if (OffX.Value == null || OffY.Value == null) return;
            ImageProcessor.Paste(father.curEnv.imgFile.Recover(), pastedImage, new Point(OffX.Value.Value, OffY.Value.Value));
            father.curEnv.imgFile.Commit();
            father.curEnv.refresh();
        }

        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
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
    }
}
