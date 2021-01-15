namespace Mandel.Extensions
{
    using Mandel.Models;
    using System.Linq;
    using System.Windows.Forms;

    public static class Extensions
    {
        public static Coordinate Transform(this Coordinate coordinate, Area fromArea, Area toArea)
        {
            return (coordinate - fromArea.Min) * (toArea.Size / fromArea.Size) + toArea.Min;
        }

        public static Area Transform(this Area area, Area fromArea, Area toArea)
        {
            return new Area(area.Min.Transform(fromArea, toArea), area.Max.Transform(fromArea, toArea));
        }

        public static Area GetArea(this PictureBox pictureBox)
        {
            return new Area(new Coordinate(0, 0), new Coordinate(pictureBox.Width, pictureBox.Height));
        }

        public static Complex ToComplex(this Coordinate coordinate)
        {
            return new Complex(coordinate.X, coordinate.Y);
        }

        public static Area Resize(this Area area, Coordinate center, double factor)
        {
            if (!area.Contains(center))
            {
                return area;
            }

            return new Area(center, area.Width * factor, area.Height * factor);
        }

        public static void Normalize(this double?[,] values)
        {
            var maxValue = values.Cast<double?>().Max();
            var minValue = values.Cast<double?>().Min();

            for (var y = 0; y < values.GetLength(1); y++)
            {
                for (var x = 0; x < values.GetLength(0); x++)
                {
                    var oldValue = values[x, y];

                    if (oldValue.HasValue)
                    {
                        values[x, y] = (oldValue - minValue) / (maxValue - minValue);
                    }
                }
            }
        }
    }
}
