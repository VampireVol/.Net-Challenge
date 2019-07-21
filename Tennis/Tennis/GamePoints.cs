namespace Tennis
{
    public class GamePoints
    {
        public int Points { get; private set; } = 0;
        public bool Domination { get; set; } = false;

        public void Add()
        {
            switch (Points)
            {
                case 0:
                    Points = 15;
                    break;
                case 15:
                    Points = 30;
                    break;
                case 30:
                    Points = 40;
                    break;
                case 40:
                    Points = 60;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Points}" + (Domination ? "+" : "");
        }
    }
}