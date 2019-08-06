using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyChallenge_1_MinAndRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, e;
            Console.WriteLine("Введите коэффиценты уравнения и точность нахождения минимума с корнями.");
            Console.Write("a = ");
            double.TryParse(Console.ReadLine(), out a);
            Console.Write("b = ");
            double.TryParse(Console.ReadLine(), out b);
            Console.Write("c = ");
            double.TryParse(Console.ReadLine(), out c);
            Console.Write("e = ");
            double.TryParse(Console.ReadLine(), out e);
            Parabola parabola = new Parabola(a, b, c);
            //Parabola parabola = new Parabola(1, 2, -3);

            FindMin findMin = new FindMin(parabola, e);
            FindRoot findRoot = new FindRoot(parabola, findMin.Min, e);
            Console.WriteLine($"Минимум функции в точке х = {findMin.Min}\n" +
                              $"Корни x1 = {findRoot.Root1} x2 = {findRoot.Root2}");
            Console.ReadKey();
        }
    }
}
