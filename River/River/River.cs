using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace River
{
    public class River
    {
        private List<Pike> _pikes;
        private List<Rudd> _rudds;
        private Random _rnd;

        private const int MaxRudds = 3000;

        public int StepsCount { get; private set; }
        public double DistanceWhenRuddDie { get; }
        public double DistanceWhenRuddBorn { get; }

        public River(double riverSize, int pikeCount, int ruddCount, int stepsCount, double distanceWhenRuddDie, double distanceWhenRuddBorn)
        {
            StepsCount = stepsCount;
            DistanceWhenRuddDie = distanceWhenRuddDie;
            DistanceWhenRuddBorn = distanceWhenRuddBorn;
            _pikes = new List<Pike>();
            _rudds = new List<Rudd>();
            _rnd = new Random();
            for (int i = 0; i < pikeCount; ++i)
            {
                _pikes.Add(new Pike((_rnd.NextDouble() - 0.5) * riverSize,
                    (_rnd.NextDouble() - 0.5) * riverSize,
                    (_rnd.NextDouble() - 0.5) * riverSize,
                    _rnd));
            }

            for (int i = 0; i < ruddCount; ++i)
            {
                _rudds.Add(new Rudd((_rnd.NextDouble() - 0.5) * riverSize,
                    (_rnd.NextDouble() - 0.5) * riverSize,
                    (_rnd.NextDouble() - 0.5) * riverSize,
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
                if (_rudds.Count < MaxRudds)
                    BornRudds();
                if (_rudds.Count != 0)
                    PikesEat();
                PikesDie();
                //Console.ReadKey();
                Thread.Sleep(100);
            }
        }

        private void BornRudds()
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

        private void PikesEat()
        {
            for (int i = 0; i < _pikes.Count; ++i)
            {
                if (_rudds.Count == 0)
                {
                    return;
                }
                List<double> length = new List<double>();
                for (int j = 0; j < _rudds.Count; ++j)
                {
                    length.Add(Math.Sqrt(Math.Pow(_pikes[i].X - _rudds[j].X, 2) +
                                         Math.Pow(_pikes[i].Y - _rudds[j].Y, 2) +
                                         Math.Pow(_pikes[i].Z - _rudds[j].Z, 2)));
                }
                double minLength = length.Min();
                if (minLength < DistanceWhenRuddDie)
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
                    _rudds.RemoveAt(minIndex);
                    _pikes[i].Eat();
                }
            }
        }

        private void PikesDie()
        {
            List<int> indexDie = new List<int>();
            for (int i = 0; i < _pikes.Count; ++i)
            {
                if (_pikes[i].IsDie())
                {
                    indexDie.Add(i);
                }
            }

            for (int i = indexDie.Count - 1; i >= 0; --i)
            {
                _pikes.RemoveAt(indexDie[i]);
            }
        }

        public override string ToString()
        {
            return $"До конца симуляций осталось итераций: {StepsCount}\n" +
                   $"Красноперок {_rudds.Count}\n" +
                   $"Щук {_pikes.Count}\n" +
                   $"Самая толстая щука:\n" +
                   $"{_pikes.Max()}\n" +
                   $"Самая тощая щука:\n" +
                   $"{_pikes.Min()}";
        }
    }
}