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
    /// CutDialog.xaml 的交互逻辑
    /// </summary>
    public partial class CutDialog : Window
    {
        private MainWindow father;
        public CutDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
            father.curEnv.selecting = true;
            father.curEnv.tabItem.selectRect.Visibility = Visibility.Visible;
            father.curEnv.selectPointA = new Point(left.Value.Value, up.Value.Value);
            father.curEnv.selectPointB = new Point(father.curEnv.imgFile.curImage.PixelWidth - right.Value.Value,
                father.curEnv.imgFile.curImage.PixelHeight - down.Value.Value);
            father.curEnv.setSelectRectPos(father.curEnv.selectPointA, father.curEnv.selectPointB);
        }

        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (father == null) return;
            left.Maximum = father.curEnv.imgFile.curImage.PixelWidth - right.Value.Value;
            right.Maximum = father.curEnv.imgFile.curImage.PixelWidth - left.Value.Value;
            up.Maximum = father.curEnv.imgFile.curImage.PixelHeight - down.Value.Value;
            down.Maximum = father.curEnv.imgFile.curImage.PixelHeight - up.Value.Value;
            father.curEnv.selectPointA = new Point(left.Value.Value, up.Value.Value);
            father.curEnv.selectPointB = new Point(father.curEnv.imgFile.curImage.PixelWidth - right.Value.Value,
                father.curEnv.imgFile.curImage.PixelHeight - down.Value.Value);
            father.curEnv.setSelectRectPos(father.curEnv.selectPointA, father.curEnv.selectPointB);
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            father.curEnv.Advance("Cut", father.curEnv.imgFile.Part(father.curEnv.selectPointA, father.curEnv.selectPointB));
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CutDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            father.curEnv.selecting = false;
            father.curEnv.tabItem.selectRect.Visibility = Visibility.Hidden;
        }
    }
}
