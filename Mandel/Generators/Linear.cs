namespace Mandel.Generators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Linear : IEnumerable<double>
    {
        public double Start { get; set; }
        public double End { get; set; }
        public double StepSize { get; set; }
        public double Value { get; set; }

        public Linear(double start, double end, int steps)
        {


            Value = Start = start;
            End = end;
            StepSize = (end - start) / steps;
        }

        public IEnumerator<double> GetEnumerator()
        { 
            while (true)
            {
                yield return Value;
                Value += StepSize;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
