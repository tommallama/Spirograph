using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Spirograph
{
    class SpiroMath
    {
        // For a primer on the spirograph mathematical basis see https://en.wikipedia.org/wiki/Spirograph
        // Equations:
        //      x(t) = R*[(1-k)*Cos(t) + l*k*Cos(t*(1-k)/k)]
        //      y(t) = R*[(1-k)*Sin(t) - l*k*Sin(t*(1-k)/k)]
        // Where:
        //      l = rho/r   --> Used to simplify the equations
        //      k = r/R     --> Used to simplify the equations
        // Hard rules:
        //      R > r > rho

        //TODO: Add comments
        public PointCollection CalculateSpiroPoints(double R, double r, double rho, double PPR, double Rot)
        {
            double start = 0.0;                                         // In Radians
            double end = 2 * Math.PI * Rot;                             // In Radians
            int numberOfPoints = (int)(Rot * PPR);                      // Number of points using points per rotation and rotations
            double linSpace = (end - start) / (double)numberOfPoints;   // Linearly point spacing in radians. Not exact but close enough
            double l = rho / r;                                         // See above for parameter description
            double k = r / R;                                           // See above for parameter description
            PointCollection points = new PointCollection();             // Actual points to be mapped 

            for (int i = 0; i < numberOfPoints; i++)
            {
                double t = start + i * linSpace;                // t is the incrementing unit and correlates to an angle
                double tempX = Xpos(t, R, l, k);                // Calculate X
                double tempY = Ypos(t, R, l, k);                // Calculate Y
                tempX = (tempX + 1) * 600;                      // Simple remapping of unit quadrants to quadrant I with max X,Y of 1200,1200
                tempY = (tempY + 1) * 600;                      // Simple remapping of unit quadrants to quadrant I with max X,Y of 1200,1200
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
