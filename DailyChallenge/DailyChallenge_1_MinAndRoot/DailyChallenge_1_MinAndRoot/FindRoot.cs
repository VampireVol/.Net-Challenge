using System;

namespace DailyChallenge_1_MinAndRoot
{
    public class FindRoot
    {
        public double Root1 { get; }

        public double Root2 { get; }

        private Parabola _parabola;

        private double _epsilon;

        public FindRoot(Parabola parabola, double min, double epsilon)
        {
            _parabola = parabola;
            _epsilon = epsilon;
            Root1 = Find(-1000, min);
            Root2 = Find(min, 1000);
        }

        private double Find(double a, double b)
        {
            double c = 0;
            while (Math.Abs(a - b) > _epsilon)
            {
                c = (a + b) / 2;
                if (_parabola.Calc(b) * _parabola.Calc(c) < 0)
                {
                    a = c;
                }
                else
                {
                    b = c;
                }
            }

            return c;
        }
    }
}