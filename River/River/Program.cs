using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace River
{
    class Program
    {
        static void Main(string[] args)
        {
            River river = new River(20, 500, 1000, 3000, 3,1.3);
            river.StartSimulations();
        }
    }
}
