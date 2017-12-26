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
using CVProject.Model;
using System.Runtime.InteropServices;

namespace CVProject
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
               
        public List<Model.Environment> envList;
        public EditMode editMode;
        public Color foreColor = Color.FromArgb(255, 255, 255, 255);
        public Color backColor = Color.FromArgb(255, 0, 0, 0);
        private int curEnvNum = -1;
        public Model.Environment curEnv
        {
            get
            {
                return curEnvNum == -1 ? null : envList[curEnvNum];
            }
        }        

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            Title = Settings.appName;
            envList = new List<Model.Environment>();;
        }

        private void OpenFile()
        {
            var t = ImageFile.Open();
            if (t != null)
            {
                envList.Add(new Model.Environment(t, this));
                curEnvNum = envList.Count - 1;
                curEnv.imgFile = t;
                Title = Settings.appName + " - " + curEnv.imgFile.FileName;
                listBox.ItemsSource = curEnv.imgFile.ImageList;
                listBox.SelectedIndex = 0;
                ResetImage();
                curEnv.setSelectRectPos(curEnv.selectPointA, curEnv.selectPointB);
                tabs.Items.Add(curEnv.tabItem);
                tabs.SelectedIndex = envList.Count - 1;
            }
        }

        private void ResetImage()
        {
            if (curEnv == null) return;
            var group = curEnv.tabItem.CurImage.FindResource("Imageview") as TransformGroup;
            var transform0 = group.Children[0] as ScaleTransform;
            var transform1 = group.Children[1] as TranslateTransform;
            transform0.ScaleX = 1;
            transform0.ScaleY = 1;
            transform1.X = 0;
            transform1.Y = 0;
        }

        private void NewFile()
        {
            var dialog = new Dialog.NewFileDialog();
            if (dialog.ShowDialog() == true)
            {
                var t = new ImageFile((int)dialog.Width.Value, (int)dialog.Height.Value, (int)dialog.Dpi.Value);
                envList.Add(new Model.Environment(t, this));
                curEnvNum = envList.Count - 1;
                curEnv.imgFile = t;
                Title = Settings.appName + " - " + curEnv.imgFile.FileName;
                listBox.ItemsSource = curEnv.imgFile.ImageList;
                listBox.SelectedIndex = 0;
                ResetImage();
                curEnv.setSelectRectPos(curEnv.selectPointA, curEnv.selectPointB);
                tabs.Items.Add(curEnv.tabItem);
                tabs.SelectedIndex = envList.Count - 1;
            }
        }

        private void SaveFile()
        {
            if (curEnv.imgFile != null)
            {
                curEnv.imgFile.Save();
                curEnv.needSave = false;
                (tabs.SelectedItem as TabItem).Header = curEnv.imgFile.FileName;
                Title = Settings.appName + " - " + curEnv.imgFile.FileName;
            }
        }

        private void SaveAs()
        {
            if (curEnv.imgFile != null)
            {
                curEnv.imgFile.SaveAs();
                curEnv.needSave = false;
                (tabs.SelectedItem as TabItem).Header = curEnv.imgFile.FileName;
                Title = Settings.appName + " - " + curEnv.imgFile.FileName;
            }
                
        }

        private void Undo()
        {
            if (curEnv.imgFile != null)
            {
                curEnv.imgFile.Undo();
                listBox.SelectedIndex = curEnv.imgFile.curStateNo;
                curEnv.needSave = true;
            }
        }

        private void Redo()
        {
            if (curEnv.imgFile != null)
            {
                curEnv.imgFile.Redo();
                listBox.SelectedIndex = curEnv.imgFile.curStateNo;
                curEnv.needSave = true;
            }
        }        

        private void Copy()
        {
            if (!curEnv.selecting) return;
            Clipboard.SetImage(curEnv.imgFile.Part(curEnv.selectPointA, curEnv.selectPointB));
            status.Text = "Copied to clipboard";
        }

        private void Paste()
        {
            curEnv.Advance("Paste");
            var dialog = new Dialog.PasteDialog(this);
            if (dialog.ShowDialog() != true)
                Undo();
        }

        private void SelectAll()
        {
            curEnv.selectPointA = new Point(0, 0);
            curEnv.selectPointB = new Point(curEnv.imgFile.curImage.PixelWidth, curEnv.imgFile.curImage.PixelHeight);
            curEnv.selecting = true;
            curEnv.setSelectRectPos(curEnv.selectPointA, curEnv.selectPointB);
            curEnv.tabItem.selectRect.Visibility = Visibility.Visible;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NewFile();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Binarization_Click(object sender, RoutedEventArgs e)
        {
            curEnv.Advance("Binarize");
            var dialog = new Dialog.BinarizationDialog(this);
            if (dialog.ShowDialog() != true)
                Undo();
        }

        private void GrayScale_Click(object sender, RoutedEventArgs e)
        {
            curEnv.Advance("Convert to grayscale");
            var dialog = new Dialog.GrayScaleDialog(this);
            if (dialog.ShowDialog() != true)
                Undo();
        }

        private void colorAdjust_Click(object sender, RoutedEventArgs e)
        {
            curEnv.Advance("Adjust Color");
            var dialog = new Dialog.ColorAdjustDialog(this);
            if (dialog.ShowDialog() != true)
                Undo();
        }

        private void edgeDetect_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialog.EdgeDetectDialog(this);
            dialog.ShowDialog();
        }

        private void arithmeticOper_Click(object sender, RoutedEventArgs e)
        {
            curEnv.Advance("Arithmetic Operation");
            var dialog = new Dialog.ArithmeticDialog(this);
            if (dialog.ShowDialog() != true)
                Undo();
        }

        private void Hough_Click(object sender, RoutedEventArgs e)
        {
            curEnv.Advance("Hough");
            ImageProcessor.houghCircle(curEnv.imgFile.curImage as WriteableBitmap, 180);
        }

        private void Smooth_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialog.SmoothingDialog(this);
            dialog.ShowDialog();
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialog.ResizeDialog(this);
            dialog.ShowDialog();
        }

        private void Rotate_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialog.RotateDialog(this);
            dialog.ShowDialog();
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialog.CutDialog(this);
            dialog.ShowDialog();
        }

        private void houghTransform_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialog.HoughDialog(this);
            dialog.ShowDialog();
        }

        private void histoBal_Click(object sender, RoutedEventArgs e)
        {
            curEnv.Advance("Histogram Balance");
            var t = curEnv.imgFile.curImage as WriteableBitmap;
            ImageProcessor.histogramBalance(t.BackBuffer, t.PixelWidth, t.PixelHeight);
        }

        private void Cursor_Click(object sender, RoutedEventArgs e)
        {
            resetToolBox();
            btnCursor.IsChecked = true;
            editMode = EditMode.Cursor;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            resetToolBox();
            btnSelect.IsChecked = true;
            editMode = EditMode.Select;
        }

        private void Brush_Click(object sender, RoutedEventArgs e)
        {
            resetToolBox();
            btnBrush.IsChecked = true;
            editMode = EditMode.Brush;
        }

        private void Eraser_Click(object sender, RoutedEventArgs e)
        {
            resetToolBox();
            btnEraser.IsChecked = true;
            editMode = EditMode.Eraser;
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            resetToolBox();
            btnLine.IsChecked = true;
            editMode = EditMode.Line;
        }

        private void Rect_Click(object sender, RoutedEventArgs e)
        {
            resetToolBox();
            btnRect.IsChecked = true;
            editMode = EditMode.Rect;
        }

        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            resetToolBox();
            btnEllipse.IsChecked = true;
            editMode = EditMode.Ellipse;
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            resetToolBox();
            btnCircle.IsChecked = true;
            editMode = EditMode.Circle;
        }

        private void PickColor_Click(object sender, RoutedEventArgs e)
        {
            resetToolBox();
            btnPickColor.IsChecked = true;
            editMode = EditMode.PickColor;
        }

        private void OpenFileCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFile();
        }

        private void SaveFileCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFile();
        }

        private void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Undo();
        }

        private void RedoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Redo();
        }

        private void CancelSelectCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            curEnv.CancelSelect();
        }

        private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Copy();
        }

        private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Paste();
        }

        private void NewFileCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NewFile();
        }

        private void SelectAllCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SelectAll();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            List<Model.Environment> delList = new List<Model.Environment>();
            for (int i = 0; i < envList.Count; i++)
            {
                tabs.SelectedIndex = 0;
                var c = envList[i];
                if (c.needSave)
                {
                    switch (Xceed.Wpf.Toolkit.MessageBox.Show(string.Format("Do you want to save {0}?", c.imgFile.FileName), Settings.appName, MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                    {
                        case MessageBoxResult.Yes:
                            SaveFile();
                            break;
                        case MessageBoxResult.No:
                            break;
                        case MessageBoxResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
                if (e.Cancel) break;
                delList.Add(c);
                tabs.Items.Remove(c.tabItem);
            }
            foreach (var c in delList)
                envList.Remove(c);
            tabs.SelectedIndex = -1;
            tabs.SelectedIndex = 0;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetImage();
        }

        private void btnForeColor_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new System.Windows.Forms.ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(foreColor.A, foreColor.R, foreColor.G, foreColor.B);
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreColor.A = colorDialog.Color.A;
                foreColor.R = colorDialog.Color.R;
                foreColor.G = colorDialog.Color.G;
                foreColor.B = colorDialog.Color.B;
                (btnForeColor.Template.FindName("ForeColorView", btnForeColor) as Rectangle).Fill = new SolidColorBrush(foreColor);
            }
        }       

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.ItemsSource == null) return;
            for (int i = 0; i <= listBox.SelectedIndex; i++)
                (listBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Foreground = new SolidColorBrush(Colors.White);
            for (int i = listBox.SelectedIndex + 1; i < curEnv.imgFile.ImageList.Count; i++)
                (listBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem).Foreground = new SolidColorBrush(Colors.Gray);
            curEnv.imgFile.ChangeState(listBox.SelectedIndex);
            curEnv.tabItem.CurImage.Source = curEnv.imgFile.curImage;
        }

        private void btnBackColor_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new System.Windows.Forms.ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(backColor.A, backColor.R, backColor.G, backColor.B);
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                backColor.A = colorDialog.Color.A;
                backColor.R = colorDialog.Color.R;
                backColor.G = colorDialog.Color.G;
                backColor.B = colorDialog.Color.B;
                (btnBackColor.Template.FindName("BackColorView", btnBackColor) as Rectangle).Fill = new SolidColorBrush(backColor);
            }
        }

        private void tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabs.SelectedIndex == -1)
            {
                if (tabs.Items.Count == 0)
                {
                    listBox.ItemsSource = null;
                    updateCurPixelInfo(Color.FromArgb(0, 0, 0, 0), 0, 0);
                }
                return;
            }
            curEnvNum = tabs.SelectedIndex;
            Title = Settings.appName + " - " + curEnv.imgFile.FileName;
            listBox.ItemsSource = curEnv.imgFile.ImageList;
            listBox.SelectedIndex = curEnv.imgFile.curStateNo;
        }

        public void updateCurPixelInfo(Color curColor, int x, int y)
        {
            colorView.Fill = new SolidColorBrush(curColor);
            RVal.Content = curColor.R;
            GVal.Content = curColor.G;
            BVal.Content = curColor.B;
            AVal.Content = curColor.A;
            var t = System.Drawing.Color.FromArgb(curColor.A, curColor.R, curColor.G, curColor.B);
            HVal.Content = t.GetHue().ToString("0.00");
            SVal.Content = (t.GetSaturation() * 100).ToString("0.00") + "%";
            LVal.Content = (t.GetBrightness() * 100).ToString("0.00") + "%";
            XVal.Content = x;
            YVal.Content = y;
        }

        private void resetToolBox()
        {
            btnBrush.IsChecked = false;
            btnCursor.IsChecked = false;
            btnCircle.IsChecked = false;
            btnEllipse.IsChecked = false;
            btnLine.IsChecked = false;
            btnEraser.IsChecked = false;
            btnRect.IsChecked = false;
            btnSelect.IsChecked = false;
            btnPickColor.IsChecked = false;
        }
    }
}
