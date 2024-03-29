﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLibraryNetwork
{
    public class District
    {
        public Guid Id { get; }

        public Guid TownId { get; }

        public string Name { get; }

        public District(string name, Guid townId)
        {
            Name = name;
            Id = Guid.NewGuid();
            TownId = townId;
        }
    }
}
