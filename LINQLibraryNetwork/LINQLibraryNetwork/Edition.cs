using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLibraryNetwork
{
    public class Edition
    {
        public Guid Id { get; }

        public int PageCount { get; }

        public Guid CopyBookId { get; }

        public Edition(int pageCount, Guid copyBookId)
        {
            PageCount = pageCount;
            CopyBookId = copyBookId;
            Id = Guid.NewGuid();
        }
    }
}
