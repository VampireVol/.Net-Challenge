using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLibraryNetwork
{
    public class Book
    {
        public Guid Id;

        public string Author { get; }

        public string Title { get; }

        public Genre Genre { get; }
        
    }
}
