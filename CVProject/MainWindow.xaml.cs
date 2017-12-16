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
        private int curEnvNum = -1;
        private Model.Environment curEnv
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
            envList = new List<Model.Environment>();
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

        private void SaveFile()
        {
            if (curEnv.imgFile != null)
            {
                curEnv.imgFile.Save();
                curEnv.needSave = false;
            }
        }

        private void SaveAs()
        {
            if (curEnv.imgFile != null)
            {
                curEnv.imgFile.SaveAs();
                curEnv.needSave = false;
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

        private void Cursor_Click(object sender, RoutedEventArgs e)
        {
            curEnv.editMode = EditMode.Cursor;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            curEnv.editMode = EditMode.Select;
        }

        private void Brush_Click(object sender, RoutedEventArgs e)
        {
            curEnv.editMode = EditMode.Brush;
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            curEnv.editMode = EditMode.Line;
        }

        private void Rect_Click(object sender, RoutedEventArgs e)
        {
            curEnv.editMode = EditMode.Rect;
        }

        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            curEnv.editMode = EditMode.Ellipse;
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            curEnv.editMode = EditMode.Circle;
        }

        private void PickColor_Click(object sender, RoutedEventArgs e)
        {
            curEnv.editMode = EditMode.PickColor;
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
            colorDialog.Color = System.Drawing.Color.FromArgb(curEnv.foreColor.A, curEnv.foreColor.R, curEnv.foreColor.G, curEnv.foreColor.B);
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                curEnv.foreColor.A = colorDialog.Color.A;
                curEnv.foreColor.R = colorDialog.Color.R;
                curEnv.foreColor.G = colorDialog.Color.G;
                curEnv.foreColor.B = colorDialog.Color.B;
                (btnForeColor.Template.FindName("ForeColorView", btnForeColor) as Rectangle).Fill = new SolidColorBrush(curEnv.foreColor);
            }
        }       

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
            colorDialog.Color = System.Drawing.Color.FromArgb(curEnv.backColor.A, curEnv.backColor.R, curEnv.backColor.G, curEnv.backColor.B);
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                curEnv.backColor.A = colorDialog.Color.A;
                curEnv.backColor.R = colorDialog.Color.R;
                curEnv.backColor.G = colorDialog.Color.G;
                curEnv.backColor.B = colorDialog.Color.B;
                (btnBackColor.Template.FindName("BackColorView", btnBackColor) as Rectangle).Fill = new SolidColorBrush(curEnv.backColor);
            }
        }

        private void tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabs.SelectedIndex == -1) return;
            curEnvNum = tabs.SelectedIndex;
            Title = Settings.appName + " - " + curEnv.imgFile.FileName;
            (btnForeColor.Template.FindName("ForeColorView", btnForeColor) as Rectangle).Fill = new SolidColorBrush(curEnv.foreColor);
            (btnBackColor.Template.FindName("BackColorView", btnBackColor) as Rectangle).Fill = new SolidColorBrush(curEnv.backColor);
            listBox.ItemsSource = curEnv.imgFile.ImageList;
            listBox.SelectedIndex = curEnv.imgFile.curStateNo;
        }
    }
}
