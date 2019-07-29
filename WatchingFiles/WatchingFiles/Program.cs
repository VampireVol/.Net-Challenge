using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"E:\watch");
            watcher.EnableRaisingEvents = true;
            watcher.Created += WatcherPrint;
            watcher.Changed += WatcherPrint;
            watcher.Deleted += WatcherPrint;
            watcher.Renamed += WatcherPrint;
            Console.ReadKey();
        }

        private static void WatcherPrint(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.FullPath} {e.Name} {e.ChangeType}");
        }
    }
}
