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
        enum EditMode { Cursor, Brush, Eraser};

        private bool mouseDown;
        private Point mouseXY;
        private bool needSave = true;
        private ImageFile imgFile;
        private Color foreColor;
        private Color backColor;
        private EditMode editMode = EditMode.Cursor;

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            RenderOptions.SetBitmapScalingMode(CurImage, BitmapScalingMode.NearestNeighbor);
            RenderOptions.SetClearTypeHint(CurImage, ClearTypeHint.Enabled);
            ImageProcessor.Init();
        }

        private void OpenFile()
        {
            var t = ImageFile.Open();
            if (t != null)
            {
                imgFile = t;
                CurImage.Source = imgFile.getCurImg();
                ResetImage();
                ImageProcessor.DrawLine(CurImage.Source as WriteableBitmap, new Point(1, 1), new Point(80, 60));
            }
        }

        private void ResetImage()
        {
            var group = CurImage.FindResource("Imageview") as TransformGroup;
            var transform0 = group.Children[0] as ScaleTransform;
            var transform1 = group.Children[1] as TranslateTransform;
            transform0.ScaleX = 1;
            transform0.ScaleY = 1;
            transform1.X = 0;
            transform1.Y = 0;
        }

        private void SaveFile()
        {
            ;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CurImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mouseDown = true;
            ImageProcessor.DrawLine(CurImage.Source as WriteableBitmap, new Point(Math.Floor(e.GetPosition(CurImage).X / CurImage.ActualWidth * imgFile.getCurImg().PixelWidth),
                Math.Floor(e.GetPosition(CurImage).Y / CurImage.ActualHeight * imgFile.getCurImg().PixelHeight)), new Point(1, 1));
            switch (editMode)
            {
                case EditMode.Cursor:
                    var img = sender as ContentControl;
                    if (img == null) return;
                    //img.CaptureMouse();                    
                    mouseXY = e.GetPosition(img);
                    break;
                case EditMode.Brush:
                    break;
            }
        }

        private void CurImage_MouseMove(object sender, MouseEventArgs e)
        {
            Point curPixel = new Point(Math.Floor(e.GetPosition(CurImage).X / CurImage.ActualWidth * imgFile.getCurImg().PixelWidth),
                Math.Floor(e.GetPosition(CurImage).Y / CurImage.ActualHeight * imgFile.getCurImg().PixelHeight));
            if (curPixel.X >= 0 && curPixel.X < imgFile.getCurImg().PixelWidth && curPixel.Y >= 0 && curPixel.Y < imgFile.getCurImg().PixelHeight)
            {
                byte[] buf = new byte[4];
                try
                {
                    (CurImage.Source as BitmapSource).CopyPixels(new Int32Rect(Convert.ToInt32(curPixel.X), Convert.ToInt32(curPixel.Y), 1, 1), buf, (CurImage.Source as BitmapSource).Format.BitsPerPixel / 8, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Color curColor = Color.FromArgb(buf[3], buf[2], buf[1], buf[0]);
                colorView.Fill = new SolidColorBrush(curColor);
                RVal.Content = curColor.R;
                GVal.Content = curColor.G;
                BVal.Content = curColor.B;
                AVal.Content = curColor.A;
                double H, S, L;
                Helper.Rgb2Hsl(curColor, out H, out S, out L);
                HVal.Content = H.ToString("0.00") + "°";
                SVal.Content = S.ToString("0.00") + "%";
                LVal.Content = L.ToString("0.00") + "%";
            }
            XVal.Content = curPixel.X;
            YVal.Content = curPixel.Y;
            if (mouseDown)
            {
                switch (editMode)
                {
                    case EditMode.Cursor:
                        var img = sender as ContentControl;
                        if (img == null)
                        {
                            return;
                        }
                        DoImgMove(img, e);
                        break;
                    case EditMode.Brush:
                        break;
                }
            }
        }

        private void CurImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseDown = false;
            switch (editMode)
            {
                case EditMode.Cursor:
                    var img = sender as ContentControl;
                    if (img == null)
                    {
                        return;
                    }
                    img.ReleaseMouseCapture();
                    break;
            }
        }

        private void DowheelZoom(TransformGroup group, Point point, double delta)
        {
            var pointToContent = group.Inverse.Transform(point);
            var transform = group.Children[0] as ScaleTransform;
            if (transform.ScaleX + delta < 0.1) return;
            transform.ScaleX *= 1 + delta;
            transform.ScaleY *= 1 + delta;
            var transform1 = group.Children[1] as TranslateTransform;
            transform1.X = -1 * ((pointToContent.X * transform.ScaleX) - point.X);
            transform1.Y = -1 * ((pointToContent.Y * transform.ScaleY) - point.Y);
        }

        private void CurImage_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var img = sender as ContentControl;
            if (img == null)
            {
                return;
            }
            var point = e.GetPosition(img);
            var group = CurImage.FindResource("Imageview") as TransformGroup;
            var delta = e.Delta * 0.001;
            DowheelZoom(group, point, delta);
        }               

        private void DoImgMove(ContentControl img, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }
            var group = CurImage.FindResource("Imageview") as TransformGroup;
            var transform = group.Children[1] as TranslateTransform;
            var position = e.GetPosition(img);
            transform.X -= mouseXY.X - position.X;
            transform.Y -= mouseXY.Y - position.Y;
            mouseXY = position;
        }

        private void OpenFileCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFile();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (needSave)
            {
                switch (Xceed.Wpf.Toolkit.MessageBox.Show("Do you want to save this file?", Settings.appName, MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
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
    }
}
