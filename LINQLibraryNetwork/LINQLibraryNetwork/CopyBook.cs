using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLibraryNetwork
{
    public class CopyBook
    {
        public Guid Id { get; }

        public Guid BookId { get; }

        public RelaseForm RelaseForm { get; }

        public CopyBook(RelaseForm relaseForm, Guid bookId)
        {
            RelaseForm = relaseForm;
            BookId = bookId;
            Id = Guid.NewGuid();
        }
    }
}
