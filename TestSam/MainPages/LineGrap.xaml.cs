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
using TestSam.MainCon;

namespace TestSam.MainPages
{
    /// <summary>
    /// Логика взаимодействия для LineGrap.xaml
    /// </summary>
    public partial class LineGrap : Page

    {
        private Line xAxisLine, yAxisLine;
        private double xAxisStart = 0, yAxisStart = 0 , interval = 50;
        private Polyline chartPolyline;

        private Point origin;
        private List<Holder> holders;
        private List<Value> values;
        private MainCon.EdMaterial edMaterial;
        private MainCon.PerformanceJournal journal;

        public Action<object, object> StateChanged { get; private set; }

        public static string UserId { get; set; }
        public LineGrap()
        {
            InitializeComponent();
            holders = new List<Holder>();
            values = new List<Value>()
            {
                new Value(1,5 * interval),
                new Value(2,4 * interval),
            };

            Paint();

            this.StateChanged += (sender, e) => Paint();
            this.SizeChanged += (sender, e) => Paint();
        }

        public class Holder
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Point Point { get; set; }

            public Holder()
            {

            }
        }

        public class Value
        {
            
            public double X { get; set; }
            public double Y { get; set; }

            public Value(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
        public void Paint()
        {
            try
            {
                if (this.ActualWidth > 0 && this.ActualHeight > 0)
                {
                    chartCanvas.Children.Clear();
                    holders.Clear();

                    // axis lines
                    xAxisLine = new Line()
                    {
                        X1 = xAxisStart,
                        Y1 = this.ActualHeight - yAxisStart,
                        X2 = this.ActualWidth - xAxisStart,
                        Y2 = this.ActualHeight - yAxisStart, 
                        Stroke = Brushes.LightGray,
                        StrokeThickness = 1,
                    }; 
                    yAxisLine = new Line()
                    {
                        X1 = xAxisStart,
                        Y1 = yAxisStart,
                        X2 = xAxisStart,
                        Y2 = this.ActualHeight - yAxisStart,
                        Stroke = Brushes.LightGray,
                        StrokeThickness = 1,
                    };

                    chartCanvas.Children.Add(xAxisLine);
                    chartCanvas.Children.Add(yAxisLine);

                    origin = new Point(xAxisLine.X1, yAxisLine.Y2);

                    var xTextBlock0 = new TextBlock() { Text = $"{0}" };
                    chartCanvas.Children.Add(xTextBlock0);
                    Canvas.SetLeft(xTextBlock0, origin.X);
                    Canvas.SetTop(xTextBlock0, origin.Y + 5);

                    // y axis lines
                    var xValue = xAxisStart;
                    double xPoint = origin.X + interval; 
                    while (xPoint < xAxisLine.X2)
                    {
                        var line = new Line()
                        {
                            X1 = xPoint,
                            Y1 = yAxisStart - 5,
                            X2 = xPoint,
                            Y2 = this.ActualHeight - yAxisStart,
                            Stroke = Brushes.LightGray,
                            StrokeThickness = 3,
                            Opacity = 1,
                        };

                        chartCanvas.Children.Add(line);

                        //var student1 = ClassConnect.con.EdMaterial.ToList().FirstOrDefault();
                        //{ 
                        //UserId = student1.Topic;
                        //}
                        
                        //var textBlock = new TextBlock { Text = $"{UserId}", }; // Вывод тем 

                        ////chartCanvas.Children.Add(textBlock);
                        //Canvas.SetLeft(textBlock, xPoint - 12.5);
                        // Canvas.SetTop(textBlock, line.Y2 + 5);

                        xPoint += interval;
                        xValue += interval;
                    }


                    var yTextBlock0 = new TextBlock();
                    chartCanvas.Children.Add(yTextBlock0);
                    Canvas.SetLeft(yTextBlock0, origin.X - 2);
                    Canvas.SetTop(yTextBlock0, origin.Y - 1);

                    // x axis lines
                    var yValue = yAxisStart;
                    double yPoint = origin.Y - interval;
                    while (yPoint > yAxisLine.Y1)
                    {
                        var line = new Line()
                        {
                            X1 = xAxisStart,
                            Y1 = yPoint,
                            X2 = this.ActualWidth - xAxisStart,
                            Y2 = yPoint,
                            Stroke = Brushes.LightGray,
                            StrokeThickness = 1.5,
                            Opacity = 1,
                        };

                        chartCanvas.Children.Add(line);

                        var textBlock = new TextBlock() { Text = $"{yValue/interval + 1}" }; //Вывод значения
                        chartCanvas.Children.Add(textBlock);
                        Canvas.SetLeft(textBlock, line.X1 + 3);
                        Canvas.SetTop(textBlock, yPoint - 1);

                        yPoint -= interval;
                        yValue += interval;
                    }

                    // connections
                    double x = 0, y = 0;
                    xPoint = origin.X;
                    yPoint = origin.Y;
                    while (xPoint < xAxisLine.X2)
                    {
                        while (yPoint > yAxisLine.Y1)
                        {
                            var holder = new Holder()
                            {
                                X = x,
                                Y = y,
                                Point = new Point(xPoint, yPoint),
                            };

                            holders.Add(holder);

                            yPoint -= interval;
                            y += interval;
                        }

                        xPoint += interval;
                        yPoint = origin.Y;
                        x += 1;
                        y = 0;
                    }

                    // Кривая линия
                    chartPolyline = new Polyline()
                    {
                        Stroke = new SolidColorBrush(Color.FromRgb(68, 114, 196)),
                        StrokeThickness = 5,
                    };
                    chartCanvas.Children.Add(chartPolyline);

                    // showing where are the connections points
                    foreach (var holder in holders)
                    {
                        Ellipse oEllipse = new Ellipse()
                        {
                            Fill = Brushes.Red,
                            Width = 10,
                            Height = 10,
                            Opacity = 0,
                        };

                        chartCanvas.Children.Add(oEllipse);
                        Canvas.SetLeft(oEllipse, holder.Point.X - 5);
                        Canvas.SetTop(oEllipse, holder.Point.Y - 5);
                    }

                    // add connection points to polyline
                    foreach (var value in values)
                    {
                        var holder = holders.FirstOrDefault(h => h.X == value.X && h.Y == value.Y);
                        if (holder != null)
                            chartPolyline.Points.Add(holder.Point);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

   
}