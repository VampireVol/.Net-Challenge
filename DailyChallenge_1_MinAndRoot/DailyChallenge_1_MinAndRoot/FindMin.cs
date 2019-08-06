using System;

namespace DailyChallenge_1_MinAndRoot
{
    public class FindMin
    {
        private double _a = -1000;

        private double _b = 1000;

        private double _epsilon;

        public double Min { get; private set; }

        private Parabola _parabola;

        public FindMin(Parabola parabola, double epsilon)
        {
            _parabola = parabola;
            _epsilon = epsilon;
            Find();
        }

        private void Find()
        {
            do
            {
                Min = (_a + _b) / 2;
                if (_parabola.Calc(Min - _epsilon) < _parabola.Calc(Min + _epsilon))
                {
                    _b = Min;
                }
                else
                {
                    _a = Min;
                }
            } while (Math.Abs(_a - _b) > _epsilon);
        }
    }
}