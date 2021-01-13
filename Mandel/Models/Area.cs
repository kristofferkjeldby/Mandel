namespace Mandel.Models
{
    using System.Drawing;

    public class Area
    {
        public Coordinate Min { get; set; }

        public Coordinate Max { get; set; }

        public Coordinate Size => Max - Min;

        public Area(Coordinate min, Coordinate max)
        {
            Min = min;
            Max = max;
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

        public double Width => Size.X;

        public double Height => Size.Y;

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
