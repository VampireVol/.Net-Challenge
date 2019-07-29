using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnyAndMyAll
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = new[] {3, 5, -5, 9, -12};
            int[] secondArr = new[] { 430, 110, 400, 500 };
            Console.WriteLine("firstArr all i < 10 " + firstArr.MyAll(i => i < 10));
            Console.WriteLine("secondArr all i < 10 " + secondArr.MyAll(i => i < 10));
            Console.WriteLine("firstArr any i < 100 " + firstArr.MyAny(i => i < 100));
            Console.WriteLine("secondArr any i < 100 " + secondArr.MyAny(i => i < 100));
            Console.WriteLine("firstArr any i < 0 && i % 2 == 0 " + firstArr.MyAny(i => i < 0 && i % 2 == 0));
            Console.WriteLine("secondArr any i < 0 && i % 2 == 0 " + secondArr.MyAny(i => i < 0 && i % 2 == 0));
            Console.ReadKey();
        }
    }
}
