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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CVProject.Control
{
    /// <summary>
    /// TabItemPlus.xaml 的交互逻辑
    /// </summary>
    public partial class TabItemPlus : TabItem
    {
        private Model.Environment father;

        public TabItemPlus(Model.Environment father)
        {
            InitializeComponent();
            this.father = father;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            father.btnClose_Click(sender, e);
        }
    }
}
