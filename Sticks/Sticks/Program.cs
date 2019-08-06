using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число палочек (Во время игры можно убирать от 1 до 3 палочек)");
            int count = int.Parse(Console.ReadLine());
            Play(count);
            Console.ReadKey();
        }

        public static void Play(int count)
        {
            Console.WriteLine($"Палочек в игре {count}");
            Console.Write("Число палочек убранных вами: ");
            int countRemove = int.Parse(Console.ReadLine());
            count -= countRemove;
            if (count == 1)
            {
                Console.WriteLine("С победой!");
                return;
            }

            int countMaster;
            if ((count - 1) % 4 == 0)
            {
                Random rnd = new Random();
                countMaster = rnd.Next(3) + 1;
                Console.WriteLine($"Мастер убрал {countMaster} палочки");
                
            }
            else
            {
                Console.WriteLine($"Мастер убрал палочек: {(count - 1) % 4}");
                countMaster = (count - 1) % 4;
            }

            count -= countMaster;
            if (count == 1)
            {
                Console.WriteLine("Вы проиграли!");
                return;
            }

            Play(count);
        }
    }
}
