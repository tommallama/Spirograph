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

namespace Spirograph
{
    /// <summary>
    /// Interaction logic for SpirographDisplay_UC.xaml
    /// </summary>
    public partial class SpirographDisplay_UC : UserControl
    {
        SpiroMath sm;

        public SpirographDisplay_UC()
        {
            InitializeComponent();
            sm = new SpiroMath();
        }


        // Clean canvas
        // Draw polyline
        // Draw dotline (so we can address individual pixel colors?)

        public void ClearCanvas()
        {
            SpiroCanvas.Children.Clear();
        }

        public void AddSpiroToCanvas(double R, double r, double rho, double PPD, double Rot)
        {
            ClearCanvas();
            PointCollection points = sm.CalculateSpiroPoints(R, r, rho, PPD, Rot);
            CreateAPolylineSpiro(points);
        }

        private void CreateAPolylineSpiro(PointCollection points)
        {
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Blue;

            // Create a polyline
            Polyline thisPolyline = new Polyline();
            thisPolyline.Stroke = blackBrush;
            thisPolyline.StrokeThickness = 2;


            //PointCollection polygonPoints = sm.CalculateSpiroPoints();

            // Set Polyline.Points properties
            thisPolyline.Points = points;

            // Add polyline to the page
            SpiroCanvas.Children.Add(thisPolyline);


        }

        private void CreatePointSpiro(PointCollection points)
        {
            // TODO: Fix math first
            //List<Point> points = sm.test();

            //foreach (var p in points)
            //{
            //    Ellipse currentEllispe = new Ellipse();
            //    currentEllispe.Height = 5;
            //    currentEllispe.Width = 5;
            //    currentEllispe.StrokeThickness = 5;
            //    currentEllispe.Stroke = Brushes.Red;

            //    Canvas.SetTop(currentEllispe, p.X);
            //    Canvas.SetLeft(currentEllispe, p.Y);
            //    SpiroCanvas.Children.Add(currentEllispe);
            //}
        }
    }
}
