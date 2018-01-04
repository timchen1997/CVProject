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
    /// MorphologyDialog.xaml 的交互逻辑
    /// </summary>
    public partial class MorphologyDialog : Window
    {
        private MainWindow father;
        private CheckBox[,] kernel = new CheckBox[7, 7];
        public MorphologyDialog(MainWindow father)
        {
            InitializeComponent();
            this.father = father;
            cboxFile.IsEnabled = false;
            foreach (var i in father.envList)
            {
                Label l = new Label();
                l.Content = i.imgFile.FileName;
                cboxFile.Items.Add(l);
            }
            cboxFile.SelectedIndex = 0;
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                {
                    var t = kernel[i, j] = new CheckBox();
                    kernelGrid.Children.Add(t);
                    Grid.SetRow(t, i);
                    Grid.SetColumn(t, j);
                    t.VerticalAlignment = VerticalAlignment.Center;
                    t.HorizontalAlignment = HorizontalAlignment.Center;
                }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            byte[] kernelArray = new byte[49];
            WriteableBitmap t, tb;
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    kernelArray[i * 7 + j] = kernel[i, j].IsChecked == true ? (byte)255 : (byte)0;
            switch (cboxMode.SelectedIndex)
            {
                case 0:
                    father.curEnv.Advance("Erode");
                    t = father.curEnv.imgFile.curImage as WriteableBitmap;
                    ImageProcessor.erode(t.BackBuffer, t.PixelWidth, t.PixelHeight, kernelArray);
                    break;
                case 1:
                    father.curEnv.Advance("Dilate");
                    t = father.curEnv.imgFile.curImage as WriteableBitmap;
                    ImageProcessor.dilate(t.BackBuffer, t.PixelWidth, t.PixelHeight, kernelArray);
                    break;
                case 2:
                    father.curEnv.Advance("Open");
                    t = father.curEnv.imgFile.curImage as WriteableBitmap;
                    ImageProcessor.open(t.BackBuffer, t.PixelWidth, t.PixelHeight, kernelArray);
                    break;
                case 3:
                    father.curEnv.Advance("Close");
                    t = father.curEnv.imgFile.curImage as WriteableBitmap;
                    ImageProcessor.close(t.BackBuffer, t.PixelWidth, t.PixelHeight, kernelArray);
                    break;
                case 4:
                    father.curEnv.Advance("Skeleton");
                    t = father.curEnv.imgFile.curImage as WriteableBitmap;
                    ImageProcessor.skeleton(t.BackBuffer, t.PixelWidth, t.PixelHeight, kernelArray);
                    break;
                case 5:
                    father.curEnv.Advance("Skeleton Rebuild");
                    t = father.curEnv.imgFile.curImage as WriteableBitmap;
                    ImageProcessor.skeletonRebuild(t.BackBuffer, t.PixelWidth, t.PixelHeight, kernelArray);
                    break;
                case 6:
                    father.curEnv.Advance("Morphological Reconstruct");
                    t = father.curEnv.imgFile.curImage as WriteableBitmap;
                    tb = father.envList[cboxFile.SelectedIndex].imgFile.curImage as WriteableBitmap;
                    ImageProcessor.morphologicalReconstruct(t.BackBuffer, tb.BackBuffer, Math.Min(t.PixelWidth, tb.PixelWidth), Math.Min(t.PixelHeight, tb.PixelHeight), kernelArray);
                    break;
                case 7:
                    father.curEnv.Advance("Distance Transform");
                    t = father.curEnv.imgFile.curImage as WriteableBitmap;
                    ImageProcessor.distanceTrans(t.BackBuffer, t.PixelWidth, t.PixelHeight, kernelArray);
                    break;
                case 8:
                    father.curEnv.Advance("Morphological Reconstruct");
                    t = father.curEnv.imgFile.curImage as WriteableBitmap;
                    tb = father.envList[cboxFile.SelectedIndex].imgFile.curImage as WriteableBitmap;
                    ImageProcessor.morphologicalReconstruct2(t.BackBuffer, tb.BackBuffer, Math.Min(t.PixelWidth, tb.PixelWidth), Math.Min(t.PixelHeight, tb.PixelHeight), kernelArray);
                    break;
            }
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void cboxMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (father == null) return;
            if (cboxMode.SelectedIndex == 6 || cboxMode.SelectedIndex == 8)
                cboxFile.IsEnabled = true;
            else
                cboxFile.IsEnabled = false;
        }
    }
}
