namespace Mandel.Models
{
    public interface ISet
    {
        double? GetValue(Complex c, int nmax, double limit);
    }
}
