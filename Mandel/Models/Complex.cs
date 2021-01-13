namespace Mandel.Models
{
    using System;

    public class Complex
    {
        public double R { get; set; }

        public double I { get; set; }

        public Complex(double r, double i)
        {
            R = r;
            I = i;
        }

        public static Complex operator +(Complex a, Complex b)
            => new Complex(a.R + b.R, a.I + b.I);

        public static Complex operator -(Complex a, Complex b)
            => new Complex(a.R - b.R, a.I - b.I);

        public static Complex operator *(Complex a, Complex b)
            => new Complex(a.R * b.R - a.I * b.I, a.R * b.I + a.I * b.R);

        public double Length()
        {
            return Math.Sqrt(Math.Pow(R, 2) + Math.Pow(I, 2));
        }

        public Complex Square()
        {
            return this * this;
        }          
    }
}