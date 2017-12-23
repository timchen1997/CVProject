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
    /// BinarizationDialog.xaml 的交互逻辑
    /// </summary>
    public partial class BinarizationDialog : Window
    {
        private MainWindow father { set; get; }

        public BinarizationDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
            radiobtnManaul.IsChecked = true;            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void radiobtnOtsu_Checked(object sender, RoutedEventArgs e)
        {
            gboxManaul.IsEnabled = false;
            refreshImage();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void radiobtnManaul_Checked(object sender, RoutedEventArgs e)
        {
            gboxManaul.IsEnabled = true;
            refreshImage();
        }

        private void refreshImage()
        {
            if (father == null) return;
            var t = father.curEnv.imgFile.Recover();
            if (radiobtnManaul.IsChecked.Value)
                ImageProcessor.binarizeImg(t.BackBuffer, t.PixelWidth, t.PixelHeight, Convert.ToBoolean(RInOut.SelectedIndex), (byte)RLow.Value.Value, (byte)RHigh.Value.Value,
                    Convert.ToBoolean(GInOut.SelectedIndex), (byte)GLow.Value.Value, (byte)GHigh.Value.Value,
                    Convert.ToBoolean(BInOut.SelectedIndex), (byte)BLow.Value.Value, (byte)BHigh.Value.Value);
            else if (radiobtnOtsu.IsChecked.Value)
                ImageProcessor.binarizeImg(t.BackBuffer, t.PixelWidth, t.PixelHeight);
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
