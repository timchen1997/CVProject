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
    /// ArithmeticDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ArithmeticDialog : Window
    {
        private MainWindow father;
        public ArithmeticDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
            foreach (var i in father.envList)
            {
                Label l = new Label();
                l.Content = i.imgFile.FileName;
                cboxImage.Items.Add(l);
            }
            cboxImage.SelectedIndex = 0;
            lblImageA.Content = father.curEnv.imgFile.FileName;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void refreshImage()
        {
            if (father == null) return;
            if (ratioA.Value == null || ratioB.Value == null) return;
            var ta = father.curEnv.imgFile.Recover();
            var tb = father.envList[cboxImage.SelectedIndex].imgFile.curImage as WriteableBitmap;
            ImageProcessor.ArithmeticOper(ta.BackBuffer, ta.PixelWidth, ta.PixelHeight, 
                tb.BackBuffer, tb.PixelWidth, tb.PixelHeight, ratioA.Value.Value, ratioB.Value.Value, cboxOp.SelectedIndex);
            father.curEnv.imgFile.Commit();
            father.curEnv.refresh();
        }

        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            refreshImage();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshImage();
        }
    }
}
