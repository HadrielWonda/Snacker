using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snacker.Domain.Common.Models;

namespace Snacker.Domain.Host.ValueObjects;

    public sealed  class HostId : ValueObject
    {
       public Guid Value { get; }
       
       private HostId(Guid value)
        {
          Value = value;
        }

        public static HostId CreateUnique() 
        { 
           return new(Guid.NewGuid());
        }

       public override IEnumerable<object> GetEqualityComponents()
        {
          yield return Value;
        }
    }
