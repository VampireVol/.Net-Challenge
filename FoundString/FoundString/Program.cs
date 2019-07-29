using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundString
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\watch";
            StringFinder find = new StringFinder();
            find.Found += FinderPrint;
            Console.Write($"Введите строку для поиска (в {path}): ");
            string line = Console.ReadLine();
            Console.WriteLine($"Поиск {line} в {path}");
            find.Start(path, line);
            Console.ReadLine();
        }

        private static void FinderPrint(object sender, EventArgs e)
        {
            Console.WriteLine($"Искомый текст найден в файле: {e.FileName}, номер строки: {e.Line}");
        }
    }
}
