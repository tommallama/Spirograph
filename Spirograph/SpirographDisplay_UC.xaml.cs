using System.Collections.Generic;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;
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
        
        // TODO: Add the ability to pick colors
        // TODO: Add the ability to cascade multiple spiros
        // TODO: Add the abolity to chose lines or discrete points
        // TODO: Put magic numbers into resource file

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

        public void CreatePointSpiro()
        {
            //TODO: Fix math first
            //List<Point> points = sm.test();

            List<Point> pts = new List<Point>();

            pts.Add(new Point(600, 600));

            foreach (var p in pts)
            {
                Ellipse currentEllispe = new Ellipse();
                currentEllispe.Height = 10;
                currentEllispe.Width = 10;
                currentEllispe.StrokeThickness = 10;
                currentEllispe.Stroke = System.Windows.Media.Brushes.Red;

                Canvas.SetTop(currentEllispe, p.X);
                Canvas.SetLeft(currentEllispe, p.Y);
                SpiroCanvas.Children.Add(currentEllispe);
            }
        }
    }
}
