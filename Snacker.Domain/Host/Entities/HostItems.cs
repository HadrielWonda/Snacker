using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;
using Snacker.Domain.Host.ValueObjects;

namespace Snacker.Domain.Host.Entities;

    public sealed class HostItems : Entity<HostItemsId>
    {
        public string Name {get; }

        public string Description {get; }

        private HostItems(HostItemsId HostItemsId,string name,string description )
        : base(HostItemsId) 
        {
            Name = name;
            Description = description;
        }

        public static HostItems Create(string name,string description)
        {
            return new(HostItemsId.CreateUnique(),name,description);
        }
    }
