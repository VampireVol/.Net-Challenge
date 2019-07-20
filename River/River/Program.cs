using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace River
{
    class Program
    {
        static void Main(string[] args)
        {
            River river = new River(20, 10, 10, 1000, 3,1.5);
            river.StartSimulations();
        }
    }

    class River
    {
        private List<Pike> _pikes;
        private List<Rudd> _rudds;
        public double RiverSize { get; private set; }
        public int PikeCount { get; private set; }
        public int RuddCount { get; private set; }
        public int StepsCount { get; private set; }
        public double DistanceWhenRuddDie { get; private set; }
        public double DistanceWhenRuddBorn { get; private set; }
        private Random _rnd;

        public River(double riverSize, int pikeCount, int ruddCount, int stepsCount, double distanceWhenRuddDie, double distanceWhenRuddBorn)
        {
            RiverSize = riverSize;
            PikeCount = pikeCount;
            RuddCount = ruddCount;
            StepsCount = stepsCount;
            DistanceWhenRuddDie = distanceWhenRuddDie;
            DistanceWhenRuddBorn = distanceWhenRuddBorn;
            _pikes = new List<Pike>();
            _rudds = new List<Rudd>();
            _rnd = new Random();
            for (int i = 0; i < PikeCount; ++i)
            {
                _pikes.Add(new Pike((_rnd.NextDouble() - 0.5) * RiverSize,
                    (_rnd.NextDouble() - 0.5) * RiverSize, 
                    (_rnd.NextDouble() - 0.5) * RiverSize,
                    _rnd));
            }

            for (int i = 0; i < RuddCount; ++i)
            {
                _rudds.Add(new Rudd((_rnd.NextDouble() - 0.5) * RiverSize,
                    (_rnd.NextDouble() - 0.5) * RiverSize,
                    (_rnd.NextDouble() - 0.5) * RiverSize,
                    _rnd));
            }
        }

        public void StartSimulations()
        {
            while (StepsCount-- > 0)
            {
                Console.Clear();
                Console.WriteLine(this);
                for (int i = 0; i < _pikes.Count; ++i)
                {
                    _pikes[i].Move();
                    //Console.WriteLine(_pikes[i]);
                }
                for (int i = 0; i < _rudds.Count; ++i)
                {
                    _rudds[i].Move();
                    //Console.WriteLine(_rudds[i]);
                }
                BornRudds();
                //Console.ReadKey();
                Thread.Sleep(100);
            }
        }

        public void BornRudds()
        {
            List<Rudd> bornRudds = new List<Rudd>();
            for (int i = 0; i < _rudds.Count - 1; ++i)
            {
                List<double> length = new List<double>();
                for (int j = i + 1; j < _rudds.Count; ++j)
                {
                    length.Add(Math.Sqrt(Math.Pow(_rudds[i].X - _rudds[j].X, 2) + 
                                         Math.Pow(_rudds[i].Y - _rudds[j].Y, 2) +
                                         Math.Pow(_rudds[i].Z - _rudds[j].Z, 2)));
                }
                double minLength = length.Min();
                if (minLength < DistanceWhenRuddBorn)
                {
                    int minIndex = 0;
                    for (int j = 0; j < length.Count; j++)
                    {
                        if (length[j] == minLength)
                        {
                            minIndex = j;
                            break;
                        }
                    }
                    bornRudds.Add(new Rudd((_rudds[i].X + _rudds[minIndex].X) / 2,
                        _rudds[i].Y + _rudds[minIndex].Y / 2,
                        _rudds[i].Z + _rudds[minIndex].Z / 2, 
                        _rnd));
                }
            }

            for (int i = 0; i < bornRudds.Count; ++i)
            {
                _rudds.Add(bornRudds[i]);
            }
        }

        public override string ToString()
        {
            return $"До конца симуляций осталось итераций: {StepsCount}\n" +
                   $"Красноперок {_rudds.Count}\n" +
                   $"Щук {_pikes.Count}";
        }
    }
}
