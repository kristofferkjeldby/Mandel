namespace Mandel.Models
{
    using System.Drawing;

    public class Coordinate
    {
        public double X { get; set; }

        public double Y { get; set; }

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Coordinate()
        {

        }

        public Coordinate(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }

        public static Coordinate operator +(Coordinate a, Coordinate b)
            => new Coordinate(a.X + b.X, a.Y + b.Y);

        public static Coordinate operator -(Coordinate a, Coordinate b)
            => new Coordinate(a.X - b.X, a.Y - b.Y);

        public static Coordinate operator *(double a, Coordinate b)
            => new Coordinate(a * b.X, a * b.Y);

        public static Coordinate operator *(Coordinate a, Coordinate b)
            => new Coordinate(a.X * b.X, a.Y * b.Y);

        public static Coordinate operator /(Coordinate a, Coordinate b)
            => new Coordinate(a.X / b.X, a.Y / b.Y);
    }
}
