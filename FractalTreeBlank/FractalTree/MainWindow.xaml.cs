using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FractalTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Brush _brush = Brushes.SteelBlue;

        public MainWindow()
        {
            Loaded += (sender, args) => DrawFractal(new Point(400, 450), 200, Math.PI / 2.5, 50);
            InitializeComponent();
        }

        private void DrawFractal(Point start, double length, double angle, int count)
        {
            var myLine = new Line
            {
                Stroke = _brush,
                X1 = start.X,
                Y1 = start.Y,
                X2 = start.X + length * Math.Cos(angle),
                Y2 = start.Y - length * Math.Sin(angle),
                StrokeThickness = 1
            };

            canvas.Children.Add(myLine);
            if (count == 0)
            {
                return;
            }
            else
            {
                //Задержка в отрисовке для создания анимации
                Sleep(100);
                DrawFractal(new Point(myLine.X2, myLine.Y2), length / 1.2, angle + Math.PI / 2.5, count - 1);
            }
        }

        private void Sleep(int ms = 1)
        {
            Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
            Thread.Sleep(ms);
        }
    }
}
