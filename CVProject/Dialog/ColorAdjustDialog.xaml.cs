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
    /// ColorAdjustDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ColorAdjustDialog : Window
    {
        private MainWindow father;
        public ColorAdjustDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void refreshImage()
        {
            if (father == null) return;
            var t = father.curEnv.imgFile.Recover();
            ImageProcessor.colorAdjust(t.BackBuffer, t.PixelWidth, t.PixelHeight, (double)Hue.Value.Value / 360.0, (double)Saturation.Value.Value / 100.0, (double)Lightness.Value.Value / 100.0);
            father.curEnv.imgFile.Commit();
            father.curEnv.refresh();
        }

        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            refreshImage();
        }
    }
}
