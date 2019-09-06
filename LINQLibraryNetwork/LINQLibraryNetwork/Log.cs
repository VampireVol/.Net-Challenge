using System;

namespace LINQLibraryNetwork
{
    public class Log
    {
        public Guid LibraryId { get; }

        public Guid VisitorId { get; }

        public Guid CopyBookId { get; }

        public DateTime Take { get; }

        public DateTime? Return
        {
            get
            {
                if (Return == null)
                {
                    Console.WriteLine();
                    return null;
                }
                else
                {
                    return Return;
                }
            }
        }
    }
}
}