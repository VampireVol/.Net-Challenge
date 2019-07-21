using System;

namespace River
{
    public class Rudd : Fish
    {
        public Rudd(double x, double y, double z, Random rnd)
            : base(x, y, z, 2, rnd)
        {

        }

        public override string ToString()
        {
            return $"Красноперка. x:{X} y:{Y} z:{Z}";
        }
    }
}