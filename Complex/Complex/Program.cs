using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            int realFirst, realSecond, imageFirst, imageSecond;
            Console.Write ("Введите вещественную часть 1 числа: ");
            realFirst = int.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть 1 числа: ");
            imageFirst = int.Parse(Console.ReadLine());
            Console.Write("Введите вещественную часть 2 числа: ");
            realSecond = int.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть 2 числа: ");
            imageSecond = int.Parse(Console.ReadLine());

            ComplexNumber first = new ComplexNumber(realFirst, imageFirst);
            ComplexNumber second = new ComplexNumber(realSecond, imageSecond);
            Console.WriteLine("Сумма чисел: {0}", first + second);
            Console.WriteLine("Разность чисел: {0}", first - second);
            Console.WriteLine("Произведение чисел: {0}", first * second);
            Console.ReadKey();
        }
    }

    
}
