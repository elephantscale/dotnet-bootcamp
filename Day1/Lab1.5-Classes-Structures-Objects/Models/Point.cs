using System;

namespace Lab1_5.Models
{
    public struct Point
    {
        // Properties
        public double X { get; set; }
        public double Y { get; set; }

        // Constructor
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Methods
        public double DistanceFromOrigin() => Math.Sqrt(X * X + Y * Y);

        public double DistanceTo(Point other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public Point MoveBy(double deltaX, double deltaY) => new Point(X + deltaX, Y + deltaY);

        // Override ToString
        public override string ToString() => $"({X}, {Y})";

        // Value equality
        public override bool Equals(object? obj) => obj is Point p && X == p.X && Y == p.Y;
        public override int GetHashCode() => HashCode.Combine(X, Y);

        // Static helpers
        public static Point Origin => new Point(0, 0);
        public static double Distance(Point p1, Point p2) => p1.DistanceTo(p2);
    }
}