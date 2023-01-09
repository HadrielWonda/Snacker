using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Domain.Common.Models;

    public class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
    {
      protected AggregateRoot(TId id) : base(id)
      {
        
      }
    }
