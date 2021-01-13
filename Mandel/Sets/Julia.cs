namespace Mandel.Sets
{
    using Mandel.Models;

    public class Julia : ISet
    {
        public Complex C { get; set; }

        public Julia(Complex c)
        {
            this.C = c;
        }

        public double? GetValue(Complex z, int nmax, double limit)
        {

            var n = 0;

            while (n < nmax)
            {
                if (z.Length() > limit)
                    return (double)n / nmax;
                z = z.Square() + C;
                n++;
            }

            return null;
        }
    }
}
