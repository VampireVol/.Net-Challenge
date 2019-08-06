using System;

namespace DailyChallenge_2_Integral
{
    public class Parabola
    {
        private double _a;

        private double _b;

        private double _c;

        public Parabola(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public double Calc(double x)
        {
            return _a * Math.Pow(x, 2) + _b * x + _c;
        }

        public override string ToString()
        {
            return $"{_a}x^2 + {_b}x + {_c}";
        }
    }
}