using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Spirograph
{
    class SpiroMath
    {
        // For a primer on the spirograph mathematical basis see https://en.wikipedia.org/wiki/Spirograph
        // Equations:
        // x(t) = R*[(1-k)*Cos(t) + l*k*Cos(t*(1-k)/k)]
        // y(t) = R*[(1-k)*Sin(t) - l*k*Sin(t*(1-k)/k)]
        // Where:
        //  l = rho/r
        //  k = r/R

        // Hard rules:
        // R > r > rho

        //const double rho = 0.10;
        //const double r = 0.32;
        //const double R = 1;
        //const double l = rho / r;
        //const double k = r / R;

        private double map(double m, double in_min, double in_max, double out_min, double out_max)
        {
            return (m - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }



        public PointCollection CalculateSpiroPoints(double R, double r, double rho, double PPD, double Rot)
        {
            double start = 0.0; // in Radians
            double end = 2 * Math.PI * Rot;   // in Radians
            int numberOfPoints = (int)(Rot * 360 * PPD);
            double linSpace = (end - start) / (double)numberOfPoints;
            double l = rho / r;
            double k = r / R;

            List<double> t = new List<double>();
            PointCollection points = new PointCollection();


            for (int i = 0; i < numberOfPoints; i++)
            {
                t.Add(start + i * linSpace);
            }

            foreach (var item in t)
            {
                double tempX = map(Xpos(item,R,l,k), -1 * R, R, 0, R*1200);
                double tempY = map(Ypos(item,R,l,k), -1 * R, R, 0, R*1200);
                points.Add(new Point(tempX, tempY));
            }
            return points;
        }


        private double Xpos(double t, double R, double l, double k)
        {
            // x(t) = R*[(1-k)*Cos(t) + l*k*Cos(t*(1-k)/k)]
            return R * ((1 - k) * Math.Cos(t) + l * k * Math.Cos(t * (1 - k) / k));
        }

        private double Ypos(double t, double R, double l, double k)
        {
            // y(t) = R*[(1-k)*Sin(t) - l*k*Sin(t*(1-k)/k)]
            return R * ((1 - k) * Math.Sin(t) - l * k * Math.Sin(t * (1 - k) / k));
        }

    }
}
