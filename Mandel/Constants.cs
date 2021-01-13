using Mandel.Models;

namespace Mandel
{
    public static class Constants
    {
        public static int MaxLoops = 100;
        public static Coordinate Min = new Coordinate(-2.1, -1.3);
        public static Coordinate Max = new Coordinate(1, 1.3);

        // Assign left side value to nulls
        public static bool NoNull = false;

        // Calibrate colors to use full gradient
        public static bool Calibrate = false;
    }
}
