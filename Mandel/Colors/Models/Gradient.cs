namespace Mandel.Colors.Models
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Gradient
    {
        public List<ColorPoint> ColorPoints { get; set; }

        public Color NullColor { get; set; }

        public Gradient(Color startColor, Color endColor, Color nullColor)
        {
            ColorPoints = new List<ColorPoint>();
            ColorPoints.Add(new ColorPoint(startColor, 0, true));
            ColorPoints.Add(new ColorPoint(endColor, 1, true));
            NullColor = nullColor;
        }

        public Color GetColor(double? value)
        {
            if (!value.HasValue || value < 0 || value > 1)
                return NullColor;

            var match = ColorPoints.FirstOrDefault(c => c.Value.Equals(value));
            if (match != null)
                return match.Color;
                
            int i;
            var sortedColorPoints = ColorPoints.OrderBy(c => c.Value).ToArray();

            for (i = 0; i < sortedColorPoints.Length; i++)
            {
                if (sortedColorPoints[i].Value > value)
                    break;
            }

            if (i == 0)
                return sortedColorPoints[0].Color;

            var left = sortedColorPoints[i - 1];
            var right = sortedColorPoints[i];

            var percent = (value.Value - left.Value) / (right.Value - left.Value);

            var red = left.Color.R + (right.Color.R - left.Color.R) * percent;
            var green = left.Color.G + (right.Color.G - left.Color.G) * percent;
            var blue = left.Color.B + (right.Color.B - left.Color.B) * percent;

            return Color.FromArgb((int)red, (int)green, (int)blue);
        }
    }
}
