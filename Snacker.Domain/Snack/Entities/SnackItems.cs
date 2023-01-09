using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;
using Snacker.Domain.Snack.ValueObjects;

namespace Snacker.Domain.Snack.Entities;

    public sealed class SnackItems : Entity<SnackItemsId>
    {
        public string Name {get; }

        public string Description {get; }

        private SnackItems(SnackItemsId SnackItemsId,string name,string description )
        : base(SnackItemsId) 
        {
            Name = name;
            Description = description;
        }

        public static SnackItems Create(string name,string description)
        {
            return new(SnackItemsId.CreateUnique(),name,description);
        }
    }
