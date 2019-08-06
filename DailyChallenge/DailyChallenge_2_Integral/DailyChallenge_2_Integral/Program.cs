using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyChallenge_2_Integral
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, e, x1, x2;
            Console.WriteLine("Введите коэффиценты уравнения и точность нахождения минимума и границы интеграла [x1, x2].");
            Console.Write("a = ");
            double.TryParse(Console.ReadLine(), out a);
            Console.Write("b = ");
            double.TryParse(Console.ReadLine(), out b);
            Console.Write("c = ");
            double.TryParse(Console.ReadLine(), out c);
            Console.Write("e = ");
            double.TryParse(Console.ReadLine(), out e);
            Console.Write("x1 = ");
            double.TryParse(Console.ReadLine(), out x1);
            Console.Write("x2 = ");
            double.TryParse(Console.ReadLine(), out x2);
            Parabola parabola = new Parabola(a, b, c);

            double integral = CalcIntegral(parabola, e, x1, x2);
            Console.WriteLine($"Полученный интеграл: {integral}");
            Console.ReadLine();
        }

        public static double CalcIntegral(Parabola parabola, double e, double a, double b)
        {
            double sum = 0;
            a += e / 2;
            while (a < b)
            {
                sum += Math.Abs(parabola.Calc(a)) * e;
                a += e;
            }
            return sum;
        }
    }
}
