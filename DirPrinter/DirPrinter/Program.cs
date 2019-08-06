using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\watch";
            PrintAllDir(path);
            Console.ReadKey();
        }

        static void PrintAllDir(string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            for (int i = 0; i < dirs.Length; ++i)
            {
                PrintAllDir(dirs[i]);
            }
            Console.WriteLine(path);
        }
    }
}
