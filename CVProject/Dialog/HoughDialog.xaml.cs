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
    /// HoughDialog.xaml 的交互逻辑
    /// </summary>
    public partial class HoughDialog : Window
    {
        private MainWindow father;
        public HoughDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
            rbtnLine.IsChecked = true;
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
            if (rbtnLine.IsChecked == true)
            {
                rmin.IsEnabled = false;
                rmax.IsEnabled = false;
            }
            else
            {
                rmin.IsEnabled = true;
                rmax.IsEnabled = true;
            }
        }
    }
}
