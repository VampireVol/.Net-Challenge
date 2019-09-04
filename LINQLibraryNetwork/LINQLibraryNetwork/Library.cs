using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLibraryNetwork
{
    public class Library
    {
        public Guid Id { get; }

        public List<Guid> CopyBooksId { get; }

        public List<Guid> VisitorsId { get; }
    }
}
