namespace Mandel.Math
{
    using Mandel.Models;
    using System;
    using Mandel.Math.Models;

    public class Mandelbrot : ISet
    {
        public double? GetValue(Coordinate coordinate, int loops)
        {
            double x1 = 0;
            double y1 = 0;
            double xx;
            var looper = 0;

            while (looper < loops)
            {
                if (!(Math.Sqrt((x1 * x1) + (y1 * y1)) < 2))
                    return (double)looper / loops;

                looper++;
                xx = (x1 * x1) - (y1 * y1) + coordinate.X;
                y1 = 2 * x1 * y1 + coordinate.Y;
                x1 = xx;
            }

            return null;
        }
    }
}
