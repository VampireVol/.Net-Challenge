using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyChallenge_3_MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            int change = 0;
            int noChange = 0;
            Random rnd = new Random();
            for (int i = 0; i < 10000; ++i)
            {
                int choice, trueChoice;
                choice = rnd.Next(3);
                trueChoice = rnd.Next(3);
                if (choice == trueChoice)
                    ++noChange;
            }

            for (int i = 0; i < 10000; ++i)
            {
                int choice, trueChoice;
                choice = rnd.Next(3);
                trueChoice = rnd.Next(3);
                if (choice != trueChoice)
                    ++change;
            }
            Console.WriteLine($"При тактике сохранения выбора: {noChange}");
            Console.WriteLine($"При тактике смены выбора: {change}");
            Console.WriteLine("Проведено два разных прогона");
            Console.ReadLine();
        }
    }
}
