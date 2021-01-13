namespace Mandel.Sets
{
    using Mandel.Models;

    public class Mandelbrot : ISet
    {
        public double? GetValue(Complex c, int nmax, double limit)
        {
            Complex z = new Complex(0, 0);
            var n = 0;

            while (n < nmax)
            {
                if (z.Length() > limit)
                    return (double)n / nmax;
                z = z.Square() + c;
                n++;
            }

            return null;
        }
    }
}
