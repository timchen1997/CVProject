using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CVProject.Model
{
    public enum EditMode { Cursor, Brush, Eraser, Line, Rect, PickColor, Ellipse, Circle, Select };
    public enum DrawMode { Link4 = 0, Link8 = 1, AntiAlias = 2}

    public class Environment
    {
        public ImageFile imgFile;
        public Point mouseXY;
        public Point selectPointA, selectPointB;
        public bool fileOpened;
        public bool selecting;        
        public bool needSave;
        public Control.TabItemPlus tabItem;
        private bool mouseDown;
        private Point startPoint, endPoint;
        private bool drawing = false;
        private bool advanced;
        private MainWindow father;

        public Environment(ImageFile img, MainWindow window)
        {
            father = window;
            selectPointA = selectPointB = new Point(0, 0);
            fileOpened = true;
            selecting = false;
            needSave = false;
            imgFile = img;
            tabItem = new Control.TabItemPlus(this);
            tabItem.CurImage.Source = imgFile.curImage;
            tabItem.Header = imgFile.FileName;
            RenderOptions.SetBitmapScalingMode(tabItem.CurImage, BitmapScalingMode.NearestNeighbor);
            RenderOptions.SetClearTypeHint(tabItem.CurImage, ClearTypeHint.Enabled);
            tabItem.contentControl.MouseLeftButtonDown += CurImage_MouseLeftButtonDown;
            tabItem.contentControl.MouseMove += CurImage_MouseMove;
            tabItem.contentControl.MouseLeftButtonUp += CurImage_MouseLeftButtonUp;
            tabItem.contentControl.MouseWheel += CurImage_MouseWheel;
            tabItem.contentControl.MouseDoubleClick += CurImage_MouseDoubleClick;
            tabItem.contentControl.MouseEnter += CurImage_MouseEnter;
            tabItem.contentControl.MouseLeave += CurImage_MouseLeave;     
        }

        private void CurImage_MouseLeave(object sender, MouseEventArgs e)
        {
            father.Cursor = Cursors.Arrow;
        }

        private void CurImage_MouseEnter(object sender, MouseEventArgs e)
        {
            switch (father.editMode)
            {
                case EditMode.Brush:
                    father.Cursor = Cursors.Pen;
                    break;
                case EditMode.Circle:
                case EditMode.Ellipse:
                case EditMode.Line:
                case EditMode.Rect:
                case EditMode.Select:
                    father.Cursor = Cursors.Cross;
                    break;
                case EditMode.Cursor:
                    father.Cursor = Cursors.SizeAll;
                    break;
                case EditMode.Eraser:
                    break;
            }
        }

        public void CancelSelect()
        {
            tabItem.selectRect.Visibility = Visibility.Hidden;
            selecting = false;
        }

        private void Advance(string description)
        {
            imgFile.Advance(description);
            father.listBox.SelectedIndex = imgFile.curStateNo;
        }

        public void setSelectRectPos(Point a, Point b)
        {
            double x1 = a.X, y1 = a.Y, x2 = b.X, y2 = b.Y;
            if (x1 > x2) Helper.Swap(ref x1, ref x2);
            if (y1 > y2) Helper.Swap(ref y1, ref y2);
            var viewPoint1 = new Point(x1 * tabItem.CurImage.ActualWidth / imgFile.curImage.PixelWidth,
                                      y1 * tabItem.CurImage.ActualHeight / imgFile.curImage.PixelHeight);
            var relaPoint1 = tabItem.CurImage.TranslatePoint(viewPoint1, tabItem.g);
            var viewPoint2 = new Point(x2 * tabItem.CurImage.ActualWidth / imgFile.curImage.PixelWidth,
                                      y2 * tabItem.CurImage.ActualHeight / imgFile.curImage.PixelHeight);
            var relaPoint2 = tabItem.CurImage.TranslatePoint(viewPoint2, tabItem.g);
            tabItem.selectRect.Margin = new Thickness(relaPoint1.X, relaPoint1.Y, tabItem.g.ActualWidth - relaPoint2.X, tabItem.g.ActualHeight - relaPoint2.Y);
        }

        private Color getPixelColor(Point pos)
        {
            byte[] buf = new byte[4];
            try
            {
                (tabItem.CurImage.Source as BitmapSource).CopyPixels(new Int32Rect(Convert.ToInt32(pos.X), Convert.ToInt32(pos.Y), 1, 1), buf, (tabItem.CurImage.Source as BitmapSource).Format.BitsPerPixel / 8, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Color.FromArgb(buf[3], buf[2], buf[1], buf[0]);
        }

        private bool InSelection(Point p)
        {
            double x1 = Math.Min(selectPointA.X, selectPointB.X),
                   x2 = Math.Max(selectPointA.X, selectPointB.X),
                   y1 = Math.Min(selectPointA.Y, selectPointB.Y),
                   y2 = Math.Max(selectPointA.Y, selectPointB.Y);
            return p.X >= x1 && p.X < x2 && p.Y >= y1 && p.Y < y2;
        }

        private Point realPoint(Point pos)
        {
            return new Point(Math.Floor(pos.X / tabItem.CurImage.ActualWidth * imgFile.curImage.PixelWidth),
                             Math.Floor(pos.Y / tabItem.CurImage.ActualHeight * imgFile.curImage.PixelHeight));
        }

        public void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (needSave){
                switch (Xceed.Wpf.Toolkit.MessageBox.Show(string.Format("Do you want to save {0}?", imgFile.FileName), Settings.appName, MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                {
                    case MessageBoxResult.Yes:
                        imgFile.Save();
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                }
            }
            int i = father.tabs.Items.IndexOf(tabItem);
            father.tabs.Items.Remove(tabItem);
            father.envList.Remove(this);
            father.tabs.SelectedIndex = -1;
            if (father.tabs.Items.Count != 0)
                father.tabs.SelectedIndex = i;
        }

        private void CurImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mouseDown = true;
            switch (father.editMode)
            {
                case EditMode.Cursor:
                    var img = sender as ContentControl;
                    if (img == null) return;
                    //img.CaptureMouse();                    
                    mouseXY = e.GetPosition(img);
                    break;
                case EditMode.Brush:
                case EditMode.Eraser:
                case EditMode.Line:
                case EditMode.Rect:
                case EditMode.Ellipse:
                case EditMode.Circle:
                    tabItem.CurImage.CaptureMouse();
                    startPoint = realPoint(e.GetPosition(tabItem.CurImage));
                    advanced = false;
                    drawing = true;
                    break;
                case EditMode.Select:
                    tabItem.CurImage.CaptureMouse();
                    selectPointA = realPoint(e.GetPosition(tabItem.CurImage));
                    selectPointB = realPoint(e.GetPosition(tabItem.CurImage));
                    setSelectRectPos(selectPointA, selectPointB);
                    tabItem.selectRect.Visibility = Visibility.Visible;
                    break;
                case EditMode.PickColor:
                    Point curPixel = realPoint(e.GetPosition(tabItem.CurImage));
                    father.foreColor = getPixelColor(curPixel);
                    (father.btnForeColor.Template.FindName("ForeColorView", father.btnForeColor) as Rectangle).Fill = new SolidColorBrush(father.foreColor);
                    break;

            }
        }

        private void CurImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!fileOpened) return;

            Point curPixel = realPoint(e.GetPosition(tabItem.CurImage));
            if (curPixel.X >= 0 && curPixel.X < imgFile.curImage.PixelWidth && curPixel.Y >= 0 && curPixel.Y < imgFile.curImage.PixelHeight)
            {
                Color curColor = getPixelColor(curPixel);
                father.updateCurPixelInfo(curColor, (int)curPixel.X, (int)curPixel.Y);
            }
            if (mouseDown)
            {
                switch (father.editMode)
                {
                    case EditMode.Cursor:
                        var img = sender as ContentControl;
                        if (img == null)
                        {
                            return;
                        }
                        DoImgMove(img, e);
                        setSelectRectPos(selectPointA, selectPointB);
                        break;
                    case EditMode.Brush:
                        if (!drawing) break;
                        if (!advanced)
                        {
                            Advance(father.editMode.ToString());
                            advanced = true;
                        }
                        endPoint = realPoint(e.GetPosition(tabItem.CurImage));
                        ImageProcessor.DrawLine(imgFile.curImage as WriteableBitmap, startPoint, endPoint, father.foreColor, (int)father.thickness.Value.Value, (DrawMode)father.drawMode.SelectedIndex);
                        startPoint = endPoint;
                        imgFile.Refresh();
                        tabItem.CurImage.Source = imgFile.curImage;
                        break;
                    case EditMode.Eraser:
                        if (!drawing) break;
                        if (!advanced)
                        {
                            Advance(father.editMode.ToString());
                            advanced = true;
                        }
                        endPoint = realPoint(e.GetPosition(tabItem.CurImage));
                        ImageProcessor.DrawLine(imgFile.curImage as WriteableBitmap, startPoint, endPoint, father.backColor, (int)father.thickness.Value.Value, (DrawMode)father.drawMode.SelectedIndex);
                        startPoint = endPoint;
                        imgFile.Refresh();
                        tabItem.CurImage.Source = imgFile.curImage;
                        break;
                    case EditMode.Line:
                        if (!drawing) break;
                        if (!advanced)
                        {
                            Advance(father.editMode.ToString());
                            advanced = true;
                        }
                        endPoint = realPoint(e.GetPosition(tabItem.CurImage));
                        ImageProcessor.DrawLine(imgFile.Recover(), startPoint, endPoint, father.foreColor, (int)father.thickness.Value.Value, (DrawMode)father.drawMode.SelectedIndex);
                        imgFile.Commit();
                        tabItem.CurImage.Source = imgFile.curImage;
                        break;
                    case EditMode.Rect:
                        if (!drawing) break;
                        if (!advanced)
                        {
                            Advance(father.editMode.ToString());
                            advanced = true;
                        }
                        endPoint = realPoint(e.GetPosition(tabItem.CurImage));
                        ImageProcessor.DrawRect(imgFile.Recover(), startPoint, endPoint, father.foreColor, (int)father.thickness.Value.Value, (DrawMode)father.drawMode.SelectedIndex);
                        imgFile.Commit();
                        tabItem.CurImage.Source = imgFile.curImage;
                        break;
                    case EditMode.Ellipse:
                        if (!drawing) break;
                        if (!advanced)
                        {
                            Advance(father.editMode.ToString());
                            advanced = true;
                        }
                        endPoint = realPoint(e.GetPosition(tabItem.CurImage));
                        ImageProcessor.DrawEllipse(imgFile.Recover(), startPoint, endPoint, father.foreColor, (int)father.thickness.Value.Value, (DrawMode)father.drawMode.SelectedIndex);
                        imgFile.Commit();
                        tabItem.CurImage.Source = imgFile.curImage;
                        break;
                    case EditMode.Circle:
                        if (!drawing) break;
                        if (!advanced)
                        {
                            Advance(father.editMode.ToString());
                            advanced = true;
                        }
                        endPoint = realPoint(e.GetPosition(tabItem.CurImage));
                        ImageProcessor.DrawCircle(imgFile.Recover(), startPoint, endPoint, father.foreColor, (int)father.thickness.Value.Value, (DrawMode)father.drawMode.SelectedIndex);
                        imgFile.Commit();
                        tabItem.CurImage.Source = imgFile.curImage;
                        break;
                    case EditMode.Select:
                        selectPointB = realPoint(e.GetPosition(tabItem.CurImage));
                        if (selectPointB.X < 0)
                            selectPointB.X = 0;
                        if (selectPointB.Y < 0)
                            selectPointB.Y = 0;
                        if (selectPointB.X >= imgFile.curImage.PixelWidth)
                            selectPointB.X = imgFile.curImage.PixelWidth;
                        if (selectPointB.Y >= imgFile.curImage.PixelHeight)
                            selectPointB.Y = imgFile.curImage.PixelHeight;
                        setSelectRectPos(selectPointA, selectPointB);
                        if (selectPointA == selectPointB)
                            selecting = false;
                        else
                            selecting = true;
                        break;
                }
            }
        }

        private void CurImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!fileOpened) return;
            mouseDown = false;
            switch (father.editMode)
            {
                case EditMode.Cursor:
                    var img = sender as ContentControl;
                    if (img == null)
                    {
                        return;
                    }
                    img.ReleaseMouseCapture();
                    break;
                case EditMode.Brush:
                case EditMode.Eraser:
                case EditMode.Line:
                case EditMode.Rect:
                case EditMode.Ellipse:
                case EditMode.Circle:
                    needSave = true;
                    drawing = false;
                    tabItem.CurImage.ReleaseMouseCapture();
                    break;
                case EditMode.Select:
                    tabItem.CurImage.ReleaseMouseCapture();
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
            if (!fileOpened) return;
            var img = sender as ContentControl;
            if (img == null)
            {
                return;
            }
            var point = e.GetPosition(img);
            var group = tabItem.CurImage.FindResource("Imageview") as TransformGroup;
            var delta = e.Delta * 0.001;
            DowheelZoom(group, point, delta);
            setSelectRectPos(selectPointA, selectPointB);
        }

        private void DoImgMove(ContentControl img, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }
            var group = tabItem.CurImage.FindResource("Imageview") as TransformGroup;
            var transform = group.Children[1] as TranslateTransform;
            var position = e.GetPosition(img);
            transform.X -= mouseXY.X - position.X;
            transform.Y -= mouseXY.Y - position.Y;
            mouseXY = position;
        }

        private void CurImage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (father.editMode != EditMode.Cursor)
                return;
            var p = realPoint(e.GetPosition(tabItem.CurImage));
            if (!InSelection(p))
                CancelSelect();
        }
    }
}
