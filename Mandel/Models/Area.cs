namespace Mandel.Models
{
    using System.Drawing;

    public class Area
    {
        public Coordinate Min { get; set; }

        public Coordinate Max { get; set; }

        public Coordinate Size => Max - Min;

        public double Width => Size.X;

        public double Height => Size.Y;

        public Area(Coordinate min, Coordinate max)
        {
            Min = min;
            Max = max;
        }

        public Area(Coordinate center, double width, double height)
        {
            Min = new Coordinate(center.X - width / 2, center.Y - height / 2);
            Max = new Coordinate(center.X + width / 2, center.Y + height / 2);
        }

        public Area()
        {

        }

        public bool IsSet()
        {
            if (Min == null || Max == null)
                return false;
            return true;
        }

        public bool Contains(Coordinate coordinate)
        {
            if (coordinate.X < Min.X || coordinate.X > Max.X)
                return false;
            if (coordinate.Y < Min.Y || coordinate.Y > Max.Y)
                return false;
            return true;
        }

        public override string ToString()
        {
            return $"{Min} -> {Max}";
        }

        public Rectangle? ToRectangle()
        {
            if (Min == null || Max == null)
                return null;

            return new Rectangle((int)Min.X, (int)Min.Y, (int)Size.X, (int)Size.Y);
        }
    }
}
