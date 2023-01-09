using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Host.ValueObjects;

namespace Snacker.Domain.Host.Entities;

    public sealed class HostSection : Entity<HostSectionId>
    {
        private readonly List<HostItems> _items = new();

        public string Name {get; }

        public string Description {get; }

        public IReadOnlyList<HostItems> Items => _items.AsReadOnly(); //or ToList.. cant pick


        private HostSection(HostSectionId HostSectionId,string name,string description)
        :base(HostSectionId)
        {
          Name = name;
          Description = description;
        }

        public static HostSection Create(string name,string description )
        {
            return new(
                HostSectionId.CreateUnique(),
                name,
                description
            );
        }
    }
