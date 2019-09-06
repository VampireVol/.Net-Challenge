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

        public Guid DistrictId { get; }

        public string Name { get; }

        public string Address { get; }

        public Library(string name, string address, Guid districtId)
        {
            Name = name;
            Address = address;
            Id = Guid.NewGuid();
            DistrictId = districtId;
        }
    }
}
