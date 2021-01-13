namespace Mandel.Math.Models
{
    using Mandel.Models;

    public interface ISet
    {
        double? GetValue(Coordinate coordinate, int loops);
    }
}
