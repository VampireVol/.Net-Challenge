using System;

namespace LINQLibraryNetwork
{
    public class LibraryVisitor
    {
        public LibraryVisitor(Guid libraryId, Guid visitorId)
        {
            LibraryId = libraryId;
            VisitorId = visitorId;
        }

        public Guid LibraryId { get; }

        public Guid VisitorId { get; }

    }
}