using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tennis
{
    class Program
    {
        static void Main(string[] args)
        {
            int skillFirstPlayer;
            int skillSecondPlayer;
            Console.WriteLine("Введите уровень мастерства игроков.\n" +
                              "Профи: 10\n" +
                              "...\n" +
                              "Новичок: 0");
            Console.Write("Уровень первого игрока: ");
            skillFirstPlayer = int.Parse(Console.ReadLine());
            Console.Write("Уровень второго игрока: ");
            skillSecondPlayer = int.Parse(Console.ReadLine());
            Tennis tennis = new Tennis(new Random(), skillFirstPlayer, skillSecondPlayer);
            tennis.StartSimulation();
            Console.ReadKey();
        }
    }
}
