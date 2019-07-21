using System;

namespace River
{
    class Pike : Fish, IComparable<Pike>
    {
        private int Weight { get; set; }

        private const int AddWeightPerEat = 5;

        public Pike(double x, double y, double z, Random rnd)
            : base(x, y, z, 5, rnd)
        {
            Weight = 5;
        }

        public override void Move()
        {
            base.Move();
            --Weight;
        }

        public void Eat()
        {
            Weight += AddWeightPerEat;
        }

        public bool IsDie()
        {
            return Weight == 0;
        }

        public int CompareTo(Pike other)
        {
            return Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return $"Щука. Вес:{Weight}\n" +
                   $"x:{X} y:{Y} z:{Z}.";
        }
    }
}