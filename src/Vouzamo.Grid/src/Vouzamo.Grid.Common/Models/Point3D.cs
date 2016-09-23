using System;

namespace Vouzamo.Grid.Common.Models
{
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double DistanceTo(Point3D target)
        {
            var dx = target.X - X;
            var dy = target.Y - Y;
            var dz = target.Z - Z;

            return Math.Sqrt(dx + dy + dz);
        }

        public static Point3D Zero => new Point3D(0, 0, 0);
    }
}
