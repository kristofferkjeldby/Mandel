namespace Mandel.Extensions
{
    using Mandel.Models;
    using System.Windows.Forms;

    public static class Extensions
    {
        public static Coordinate Transform(this Coordinate coordinate, Area fromArea, Area toArea)
        {
            return (coordinate - fromArea.Min) * (toArea.Size/fromArea.Size) + toArea.Min;
        }

        public static Area Transform(this Area area, Area fromArea, Area toArea)
        {
            return new Area(area.Min.Transform(fromArea, toArea), area.Max.Transform(fromArea, toArea));
        }

        public static Area GetArea(this PictureBox pictureBox)
        {
            return new Area(new Coordinate(0, 0), new Coordinate(pictureBox.Width, pictureBox.Height));
        }
    }
}
