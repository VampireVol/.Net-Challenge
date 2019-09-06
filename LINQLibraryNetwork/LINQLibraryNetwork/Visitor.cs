using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLibraryNetwork
{
    public class Visitor
    {
        public Guid Id { get; }

        public string Name { get; }

        public Visitor(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
    }
}
