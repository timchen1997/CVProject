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
    /// JpegSaveDialog.xaml 的交互逻辑
    /// </summary>
    /// 

    
    public partial class JpegSaveDialog : Window
    {
        public int Quality { set; get; }

        public JpegSaveDialog()
        {
            InitializeComponent();
            Quality = 100;
            ShowDialog();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Quality = (int)slider.Value;
            Close();
        }
    }
}
