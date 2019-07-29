using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundString
{
    public class EventArgs
    {
        public EventArgs(string fileName, int line)
        {
            FileName = fileName;
            Line = line;
        }

        public string FileName { get; }

        public int Line { get; }
    }
}
