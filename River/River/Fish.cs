using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace River
{
    public abstract class Fish
    {
        protected Fish(double x, double y, double z, int maxSpeed, Random rnd)
        {
            X = x;
            Y = y;
            Z = z;
            MaxSpeed = maxSpeed;
            _rnd = rnd;
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public double Z { get; private set; }

        public int MaxSpeed { get; }

        private Random _rnd;

        public virtual void Move()
        {
            var curSpeed = _rnd.Next(MaxSpeed + 1);
            var dX = (_rnd.NextDouble() - 0.5) * 2 * curSpeed;
            var maxY = Math.Sqrt(Math.Pow(curSpeed, 2) - Math.Pow(dX, 2));
            var dY = (_rnd.NextDouble() - 0.5) * 2 * maxY;
            var dZ = PlusOrMinus() * Math.Sqrt(Math.Pow(curSpeed, 2) - Math.Pow(dX, 2) - Math.Pow(dY, 2));
            X += dX;
            Y += dY;
            Z += dZ;
            //Console.WriteLine($"{curSpeed} {Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2) + Math.Pow(dZ, 2))}");
        }

        private int PlusOrMinus()
        {
            return (_rnd.NextDouble() - 0.5) > 0 ? 1 : -1;
        }

    }
}
