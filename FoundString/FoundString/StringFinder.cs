using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundString
{
    class StringFinder
    {
        public EventHandler<EventArgs> Found;

        public void Start(string path, string text)
        {
            string[] fileNames = Directory.GetFiles(path);
            for (int i = 0; i < fileNames.Length; ++i)
            {
                string fullPath = Path.Combine(path, fileNames[i]);
                string[] allLines = File.ReadAllLines(fullPath);
                for (int j = 0; j < allLines.Length; ++j)
                {
                    if (allLines[j] == text)
                    {
                        Found(this, new EventArgs(fileNames[i], j));
                    }
                }
            }
        }
    }
}
