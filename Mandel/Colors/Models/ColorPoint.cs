namespace Mandel.Colors.Models
{
    using System.Drawing;

    public class ColorPoint
    {
        public Color Color { get; set; }

        public double Value { get; set; }

        public bool Locked { get; set; }

        public ColorPoint(Color color, double value, bool locked)
        {
            Color = color;
            Value = value;
            Locked = locked;
        }
    }
}
